using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Text;
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
        private readonly IConfiguration _configuration;

        public AdminController(TraSuaContext context, IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _configuration = configuration;
            _worker = new Worker(_context, _configuration);
        }

        public IActionResult Index()
        {
            var listProduct = _worker.productRepository.GetAll();
            return View(listProduct);
        }

        public ActionResult CreateProduct()
        {
            CreateProductDto createProductDto = new CreateProductDto
            {
                Categories = ProductData.getCategoryList(_context)
            };
            return View(createProductDto);
        }

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

                _worker.productRepository.Add(newProduct);
                _worker.productRepository.SaveChanges();

            }
            return RedirectToAction("productManager", "Admin");

        }
        public ActionResult EditProduct(int id)
        {
            Product product = _worker.productRepository.FindById(id);
            List<SelectListItem> categories = ProductData.getCategoryList(_context);
            foreach (var i in categories)
            {
                if (i.Value == product.CategoryId.ToString())
                {
                    i.Selected = true;
                }
            }

            CreateProductDto initProduct = new CreateProductDto
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                CategoryId = product.CategoryId,
                Categories = categories,
                Thumbnail_string = product.Thumbnail
            };
            return View(initProduct);
        }

        public ActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(EditUserDto createUserDto)
        {
            if (ModelState.IsValid)
            {
                string folder = "upload/user/";

                if (createUserDto.Avatar_Upload != null)
                {
                    folder += Guid.NewGuid().ToString() + "-" + createUserDto.Avatar_Upload.FileName;
                    string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                    await createUserDto.Avatar_Upload.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                }

                User newUser = new User
                {
                    UserName = createUserDto.UserName,
                    FullName = createUserDto.FullName,
                    PhoneNumber = createUserDto.PhoneNumber,
                    Email = createUserDto.Email,
                    Password = createUserDto.Password,
                    Avatar = folder,
                    Role = createUserDto.Role
                };
                _worker.userRepository.AddUser(newUser);
                _worker.userRepository.SaveChanges();

            }
            return RedirectToAction("userManager", "Admin");
        }

        public ActionResult EditUser(int id)
        {
            User user = _worker.userRepository.FindById(id);
            EditUserDto initUser = new EditUserDto
            {
                UserName = user.UserName,
                FullName = user.FullName,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                Password = user.Password,
                Avatar = user.Avatar,
                Role = user.Role
            };
            return View(initUser);
        }



        [HttpPost]
        public async Task<IActionResult> EditUser(EditUserDto editUserDto)
        {
            if (ModelState.IsValid)
            {
                string folder = "upload/user/";

                if (editUserDto.Avatar_Upload != null)
                {
                    folder += Guid.NewGuid().ToString() + "-" + editUserDto.Avatar_Upload.FileName;
                    string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                    await editUserDto.Avatar_Upload.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                }
                User initUser = _context.User.Where(x => x.UserName == editUserDto.UserName).FirstOrDefault();

                initUser.UserName = editUserDto.UserName;
                initUser.FullName = editUserDto.FullName;
                initUser.PhoneNumber = editUserDto.PhoneNumber;
                initUser.Email = editUserDto.Email;
                initUser.Avatar = folder;
                initUser.Role = editUserDto.Role;

                _worker.userRepository.UpdateUser(initUser);
                _context.SaveChanges();

            }
            return RedirectToAction("userManager", "Admin");

        }

        [HttpPost]
        public async Task<IActionResult> EditProduct(CreateProductDto createProductDto)
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

                Product initProduct = _context.Product.Where(x => x.Name == createProductDto.Name).FirstOrDefault();

                initProduct.Name = createProductDto.Name;
                initProduct.Description = createProductDto.Description;
                initProduct.Price = createProductDto.Price;
                initProduct.Thumbnail = folder;
                initProduct.CategoryId = createProductDto.CategoryId;

                _worker.productRepository.Add(initProduct);
                _context.SaveChanges();
            }
            return RedirectToAction("productManager", "Admin");
        }

        //Template Method
        public ActionResult CreateOrder()
        {
            return View();
        }

            
        public IActionResult ProductManager()
        {
            return View(_worker.productRepository.GetAll());
        }
        public IActionResult UserManager()
        {
            return View(_worker.userRepository.AllUser());
        }
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
     
        public async Task<Order> GetOrder(int orderId)
        {
            return await _context.Order
                .Include(o => o.OrderDetails)
                .ThenInclude(orderDetail => orderDetail.Product)
                .FirstOrDefaultAsync(x => x.Id == orderId)
                    ?? throw new Exception("Order not found");
        }

    }
}
