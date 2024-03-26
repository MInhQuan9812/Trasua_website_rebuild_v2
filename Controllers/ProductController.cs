using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using trasua_web_mvc.CommonData;
using trasua_web_mvc.Dtos;
using trasua_web_mvc.Infracstructures;
using trasua_web_mvc.Infracstructures.Composite;
using trasua_web_mvc.Infracstructures.Entities;
using trasua_web_mvc.Infracstructures.Singleton;
using trasua_web_mvc.Repositories;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace trasua_web_mvc.Controllers
{
    public class ProductController : Controller
    {

        private readonly TraSuaContext _context;
        private Worker _worker;
        private readonly IConfiguration _configuration;
        private readonly CompositeSearch _compositeSearch;


        public ProductController(TraSuaContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
            _worker = new Worker(_context, _configuration);
            _compositeSearch = new CompositeSearch();
        }

        public IActionResult Index(string? keyword, int? categoryId, int? minPrice, int? maxPrice)
        {
            var product = _worker.productRepository.GetAll();
            if (keyword == null && categoryId == null && minPrice == null && maxPrice == null) 
            {
                return View(product);
            }
            else
            {
                _compositeSearch.AddComponent(new SearchName(product.ToList()));
                _compositeSearch.AddComponent(new SearchByPrice(product.ToList()));
                _compositeSearch.AddComponent(new SearchByCategory(product.ToList()));
                var results = _compositeSearch.Search(keyword, categoryId, minPrice, maxPrice);
                return View(results);
            }
        }


        public  ActionResult Detail(int id)
        {
            Product product = _worker.productRepository.FindById(id);

            ProductDetailDto productDetail = new ProductDetailDto
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Thumbnail = product.Thumbnail,
                Toppings = ProductData.getToppingList(_context,id),
                Sizes=ProductData.getSizeList(_context,product.Id),
                Ingredients=ProductData.getIngredientList(_context,id)
            };
            OptionSingleton.Instance.ClearData();
            return View(productDetail);
        }


        [HttpPost]
        public async Task<IActionResult> AddDetailItem(ProductDetailDto productDetailDto)
        {
            var product = _context.Product.Where(x => x.Name.Contains(productDetailDto.Name)).FirstOrDefault();
            var user = _context.User.Where(x => x.UserName.Equals(User.Identity.Name)).FirstOrDefault();
            var cartCount = await _worker.cartRepository.AddItem(product.Id, user.Id, 1,productDetailDto);
            return RedirectToAction("Index", "Cart");
        }

    }
}
