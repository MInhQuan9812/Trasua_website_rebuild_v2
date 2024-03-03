using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using trasua_web_mvc.CommonData;
using trasua_web_mvc.Dtos;
using trasua_web_mvc.Infracstructures;
using trasua_web_mvc.Infracstructures.Entities;
using trasua_web_mvc.Repositories;

namespace trasua_web_mvc.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly TraSuaContext _context;
        private Worker _worker;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AdminController(TraSuaContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _worker = new Worker(_context);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            var listProduct = _worker.productRepository.AllProduct();
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult CreateProduct()
        {
            CreateProductDto createProductDto = new CreateProductDto
            {
                Categories = ProductData.getCategoryList(_context)
            };
            return View(createProductDto);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            List<Category> categoryList = new List<Category>();
            if (ModelState.IsValid)
            {
                string folder = "upload/cover/";

                if (createProductDto.Description == null)
                {
                    createProductDto.Description = CommonFunction.GetDescriptionFromContent(createProductDto.Description);
                }
                if (createProductDto.Thumbnail != null)
                {
                    folder += Guid.NewGuid().ToString() + "-" + createProductDto.Thumbnail.FileName;
                    string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                    await createProductDto.Thumbnail.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                }

                Product newProduct = new Product
                {
                    Name = createProductDto.Name,
                    Description = createProductDto.Description,
                    CategoryId = createProductDto.CategoryId,
                    Thumbnail = folder,
                    Price = createProductDto.Price
                };
                _worker.productRepository.AddProduct(newProduct);
                _worker.productRepository.SaveChanges();
                
            }
            return RedirectToAction("productManager","Admin");

        }


        [Authorize(Roles = "Admin")]
        public IActionResult ProductManager()
        {
            return View(_worker.productRepository.AllProduct());
        }
        [Authorize(Roles = "Admin")]
        public IActionResult UserManager()
        {
            return View(_worker.userRepository.AllUser());
        }
        [Authorize(Roles = "Admin")]
        public IActionResult CategoryManager()
        {
            return View(_worker.categoryRepository.AllCategory());
        }

        public IActionResult BranchManager()
        {
            return View();
        }

        public IActionResult OrderManager()
        {
            return View();
        }

    }
}
