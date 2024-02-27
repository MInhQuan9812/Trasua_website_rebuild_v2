using Microsoft.AspNetCore.Mvc;
using trasua_web_mvc.Infracstructures;
using trasua_web_mvc.Repositories;

namespace trasua_web_mvc.Controllers
{
    public class AdminController : Controller
    {
        private readonly TraSuaContext _context;
        private Worker _worker;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public AdminController(TraSuaContext context,Worker worker)
        {
            _context = context;
            _worker = worker;
        }

        public IActionResult Index()
        {
            return View();
        }


    }
}
