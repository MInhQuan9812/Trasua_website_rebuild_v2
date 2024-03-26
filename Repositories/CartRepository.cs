using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using trasua_web_mvc.Dtos;
using trasua_web_mvc.Infracstructures;
using trasua_web_mvc.Infracstructures.Decorator;
using trasua_web_mvc.Infracstructures.Entities;
using trasua_web_mvc.Infracstructures.Observer;

namespace trasua_web_mvc.Repositories
{
    public class CartRepository: ISubject
    {
          
        private readonly TraSuaContext _context;
        private Worker _worker;
        private readonly IConfiguration _configuration;
        private List<IObserver> _observers = new List<IObserver>();

        public int State { get; set; }
        public string AlertMessage { get; set; }

        public CartRepository(TraSuaContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
            _worker = new Worker(context, _configuration);
        }
        public async Task<int> AddItem(int productId, int userId, int qty,ProductDetailDto? productDetailDto)
        {
            try
            {
                if (userId == null)
                {
                    throw new Exception("user is not logged-in");
                }
                Cart cart = await GetCart(userId);

                if (cart == null)
                {
                    cart = new Cart
                    {
                        CustomerId = userId
                    };
                    _context.Cart.Add(cart);
                }
                _context.SaveChanges();

                var cartItem = _context.CartItem.FirstOrDefault(x => x.CartId == cart.Id && x.ProductId == productId);

                if (cartItem != null)
                {
                    cartItem.Quantity += qty;
                }
                else
                {
                    var product = _context.Product.Find(productId);
                    cartItem = new CartItem
                    {
                        ProductId = productId,
                        CartId = cart.Id,
                        Quantity = qty,
                        Product = product
                    };
                    _context.CartItem.Add(cartItem);
                }
                var user = await _context.User.FirstOrDefaultAsync(x => x.Id == userId);
                user.Cart = cart;
                cart.CartItems.Add(cartItem);
                _context.SaveChanges();

                State = qty;
                this.Notify();
            }
            catch (Exception ex)
            {

            }
            var cartItemCount = await GetCartItemCount(userId);
            return cartItemCount;
        }

        //product.ProductOptionValues=_context.ProductOptionValue.Include(x=>x.Product)
        //    .Include(x=>x.OptionValue)
        //    .Include(x=>x.Option)
        //    .Where(x=>x.ProductId==productId).ToList();


        //
        //IProduct productDecorator = new Product();


        //List<ProductOptionData> listData = new List<ProductOptionData>(); 
        //foreach( var item in productDetailDto.Toppings)
        //{
        //    if(item.IsChecked == true){
        //        ProductOptionData productOptionData = new ProductOptionData
        //        {
        //            ProductOptionId = item.Id,
        //            Price = item.Price,
        //            IsChecked = item.IsChecked,
        //            LabelName = item.LabelName,
        //        };
        //        listData.Add(productOptionData);
        //    }
        //}
        //productDecorator.


        public async Task<List<ProductOptionValue>> FindProductHasOption(int productId)
        {
            if (productId == null)
                throw new Exception("Error");
            var product = await _context.ProductOptionValue.Where(x => x.ProductId == productId).ToListAsync();
            return product;
        }

        public async Task<Cart> GetUserCart(int userId)
        {

            if (userId == null)
                throw new Exception("Invalid userid");
            var shoppingCart = await _context.Cart
                                  .Include(a => a.CartItems)
                                  .ThenInclude(a => a.Product)
                                  .Where(a => a.CustomerId == userId).FirstOrDefaultAsync();
            return shoppingCart;

        }

        public async Task<int> GetCartItemCount(int userId)
        {
            var data = await (from cart in _context.Cart
                              join cartItem in _context.CartItem
                              on cart.Id equals cartItem.CartId
                              where cart.CustomerId == userId
                              select new { cartItem.Id }
                        ).ToListAsync();
            return data.Count;
        }

        public async Task<Cart> GetCart(int userId)
        {
            return await _context
                .Cart
                .Include(a => a.CartItems)
                .ThenInclude(a => a.Product)
                .ThenInclude(a=>a.ProductOptionValues)
                .ThenInclude(x=>x.OptionValue)
                .FirstOrDefaultAsync(x => x.CustomerId == userId);
        }

        public async Task CheckOut(int userId, CheckoutDto checkoutDto)
        {

            var cart = await GetCart(userId)
              ?? throw new Exception("Invalid cart");
            var order = new Order
            {
                CustomerId = userId,
                Created = DateTime.Now,
                Address = checkoutDto.Address,
                PaymentId = checkoutDto.PaymentId,
                PromotionId = checkoutDto.PromotionId,
            };

            int? total = 0;

            foreach (var lineItem in cart.CartItems.ToList())
            {
                var orderDetail = new OrderDetail
                {
                    ProductId = lineItem.Product.Id,
                    UnitPrice = lineItem.Product.Price,
                    Quantity = lineItem.Quantity,
                    TotalPrice = lineItem.Product.Price * lineItem.Quantity,
                };

                order.OrderDetails.Add(orderDetail);
                total += orderDetail.TotalPrice;
            }
            order.Total = total;

            _context.Add(order);
            _context.SaveChanges();
        }
        public async Task<int?> GetTotalCheckout(int userId, CheckoutDto checkoutDto)
        {

            var cart = await GetCart(userId)
              ?? throw new Exception("Invalid cart");
            int? total = 0;

            foreach (var lineItem in cart.CartItems.ToList())
            {
                var orderDetail = new OrderDetail
                {
                    ProductId = lineItem.Product.Id,
                    UnitPrice = lineItem.Product.Price,
                    Quantity = lineItem.Quantity,
                    TotalPrice = lineItem.Product.Price * lineItem.Quantity,
                };

                total += orderDetail.TotalPrice;
            }
            return total;
        }

        public async Task<int> GetPrice(int productId)
        {
            var product = await _context.Product.FirstOrDefaultAsync(x => x.Id == productId);
            return product.Price;
        }

        public async Task<int> RemoveItem(int userId, int productId)
        {
            try
            {
                if (userId == null)
                    throw new Exception("user is not logged-in");
                var cart = await GetCart(userId);
                if (cart is null)
                    throw new Exception("Invalid cart");

                var cartItem = _context.CartItem
                                  .FirstOrDefault(a => a.CartId == cart.Id && a.ProductId == productId);
                if (cartItem is null)
                    throw new Exception("Not items in cart");
                else if (cartItem.Quantity == 1)
                    _context.CartItem.Remove(cartItem);
                else
                    cartItem.Quantity = cartItem.Quantity - 1;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error");
            }
            var cartItemCount = await GetCartItemCount(userId);
            return cartItemCount;
        }

        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update(this);
            }
        }
    }
}
