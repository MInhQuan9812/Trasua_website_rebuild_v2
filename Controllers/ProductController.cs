using Microsoft.AspNetCore.Mvc;
using trasua_web_mvc.Infracstructures;
using trasua_web_mvc.Repositories;

namespace trasua_web_mvc.Controllers
{
    public class ProductController:Controller
    {

        private readonly TraSuaContext _context;
        private Worker _worker;
        private readonly IConfiguration _configuration;


        public ProductController(TraSuaContext context,IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
            _worker = new Worker(_context, _configuration);
        }

        public IActionResult Index(string title=null, string category=null, int? minPrice=null, int? maxPrice = null)
        {
            //if (!string.IsNullOrEmpty(title))
            //{
            //    return View(_context.Product.Where(p => p.Name.Contains(title)).ToList());
            //}

            //if (!string.IsNullOrEmpty(category))
            //{

            //}

            //if (minPrice.HasValue)
            //{
            //}

            //if (maxPrice.HasValue)
            //{
            //}
            
            return View(_worker.productRepository.GetAll());
        }


    }
}
