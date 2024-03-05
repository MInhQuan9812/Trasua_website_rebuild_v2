using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using trasua_web_mvc.Infracstructures;
using trasua_web_mvc.Infracstructures.Entities;
using trasua_web_mvc.Repositories;

namespace trasua_web_mvc.Controllers
{
    public class CartController : Controller
    {

        private readonly TraSuaContext _context;
        private Worker _worker;

        public CartController(TraSuaContext context)
        {
            _context = context;
            _worker = new Worker(_context);
        }
        
        public async Task<IActionResult> Index()
        {
            var user =  _context.User.Where(x => x.UserName.Equals(User.Identity.Name)).FirstOrDefault();
            var cart = await _worker.cartRepository.GetUserCart(user.Id);
            return View(cart);
        }


        public async Task<IActionResult> AddItem(int productId)
        {
            var user = _context.User.Where(x => x.UserName.Equals(User.Identity.Name)).FirstOrDefault();
            var cartCount=await _worker.cartRepository.AddItem(productId,user.Id, 1);
            return RedirectToAction("Index", "Cart");

        }


    }
}
