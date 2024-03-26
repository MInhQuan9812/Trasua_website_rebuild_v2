using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using trasua_web_mvc.CommonData;
using trasua_web_mvc.Dtos;
using trasua_web_mvc.Infracstructures;
using trasua_web_mvc.Infracstructures.Entities;
using trasua_web_mvc.Infracstructures.Observer;
using trasua_web_mvc.Repositories;

namespace trasua_web_mvc.Controllers
{
    public class CartController : Controller
    {
        private readonly TraSuaContext _context;
        private Worker _worker;
        private readonly IConfiguration _configuration;
        public CartController(TraSuaContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
            _worker = new Worker(_context, _configuration);
        }

        public async Task<IActionResult> Index()
        {
            var user = _context.User.Where(x => x.UserName.Equals(User.Identity.Name)).FirstOrDefault();
            var cart = await _worker.cartRepository.GetUserCart(user.Id);           
            return View(cart);
        }


        public async Task<IActionResult> AddItem(int productId)
        {
            var notifyService = new NotityService();
            _worker.cartRepository.Attach(notifyService);
            var user = _context.User.Where(x => x.UserName.Equals(User.Identity.Name)).FirstOrDefault();

            await _worker.cartRepository.AddItem(productId, user.Id, 1, null);

            ConfigAlert(_worker.cartRepository.AlertMessage);

            return RedirectToAction("Index", "Cart");
        }


        public async Task<ActionResult> Checkout()
        {
            var user = _context.User.Where(x => x.UserName.Equals(User.Identity.Name)).FirstOrDefault();
            var cart = await _worker.cartRepository.GetUserCart(user.Id);
            CheckoutDto checkoutDto = new CheckoutDto
            {
                FullName = user.FullName,
                PhoneNumber = user.PhoneNumber,
                PaymentMethods = OrderData.getPaymentList(_context),
                CartItems = cart.CartItems.ToList()
            };
            return View(checkoutDto);
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(CheckoutDto checkoutDto)
        {
            //xử lí đầu vào paymentId=> nếu payment không phải palpall
            // không thì sử dụng checkout vs paypal
            var user = _context.User.Where(x => x.UserName.Equals(User.Identity.Name)).FirstOrDefault()
                        ?? throw new Exception("User is not logged");
            if (checkoutDto.PaymentId != 9)
            {
                try
                {
                    await _worker.cartRepository.CheckOut(user.Id, checkoutDto);
                    return RedirectToAction("Index", "Home");
                }
                catch (Exception ex)
                {
                    throw new Exception("Error");
                }
            }
            else
            {
                var _amount = await _worker.cartRepository.GetTotalCheckout(user.Id, checkoutDto);
                return RedirectToAction("PayUsingPaypal", "Payment", new { amount = _amount });
            }
        }

        public async Task<IActionResult> RemoveItem(int productId)
        {
            var user = _context.User.Where(x => x.UserName.Equals(User.Identity.Name)).FirstOrDefault()
                    ?? throw new Exception("User is not logged");
            var removedItem = await _worker.cartRepository.RemoveItem(user.Id, productId);
            return RedirectToAction("Index", "Cart");
        }
        protected void ConfigAlert(string message)
        {
            TempData["AlertMessage"] = message;         
        }


    }
}
