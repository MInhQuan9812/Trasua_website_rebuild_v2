using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using trasua_web_mvc.Infracstructures;
using trasua_web_mvc.Infracstructures.Entities;

namespace trasua_web_mvc.Repositories
{
    public class CartRepository
    {
        private readonly TraSuaContext _context;


        public CartRepository(TraSuaContext context )
        {
            _context = context;

        }
        public async Task<int> AddItem(int productId, int userId, int qty)
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
                    };
                    _context.CartItem.Add(cartItem);
                }
                var user=await _context.User.FirstOrDefaultAsync(x=>x.Id== userId);
                user.Cart = cart;
                cart.CartItems.Add(cartItem);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

            }
            var cartItemCount = await GetCartItemCount(userId);
            return cartItemCount;
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
            var cart = await _context.Cart.FirstOrDefaultAsync(x => x.CustomerId == userId);
            return cart;
        }


    }
}
