using Microsoft.AspNetCore.Mvc;
using trasua_web_mvc.Infracstructures;
using trasua_web_mvc.Infracstructures.Entities;
using trasua_web_mvc.Repositories;

namespace trasua_web_mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TraSuaContext _context;
        private Worker _worker;


        public HomeController(ILogger<HomeController> logger, TraSuaContext context)
        {
            _logger = logger;
            _context = context;
            _worker = new Worker(_context);
        }
        public IActionResult Index()
        {

            return View();
        }
    }
}
