using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security;
using System.Security.Claims;
using trasua_web_mvc.Infracstructures;
using trasua_web_mvc.Infracstructures.Entities;
using trasua_web_mvc.NewFolder;
using trasua_web_mvc.Repositories;

namespace trasua_web_mvc.Controllers
{
    public class UserController : Controller
    {
        private readonly TraSuaContext _context;
        private Worker _worker;
        private readonly IConfiguration _configuration;

        public UserController(TraSuaContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
            _worker = new Worker(_context, _configuration);
        }


        public async Task<ActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index","Home");
        }

        [HttpPost]
        public async Task<ActionResult> Login([Bind(include: "UserName,Password")] LoginDto user)
        {
            if (ModelState.IsValid)
            {
                var account = _context.User.FirstOrDefault(x => x.UserName.Equals(user.UserName) && x.Password.Equals(CommonData.CommonFunction.GetHashString(user.Password)));
                if (account != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name,account.UserName),
                        new Claim(ClaimTypes.Role,account.Role),
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties=new AuthenticationProperties();

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,new ClaimsPrincipal(claimsIdentity),authProperties);
                    return RedirectToAction("Index", "Home");
                }                
            }
            return View();
        }

        public IActionResult Profile()
        {
            string userName = User.Identity.Name;
            User user=_context.User.Where(x=>x.UserName==userName).FirstOrDefault();
            return View(user);
        }

        [HttpPost]
        public async Task<ActionResult> SignUp([Bind(include: "UserName,FullName,PhoneNumber,Email,Password,Gender,")] User user)
        {
            if(ModelState.IsValid)
            {
                var account=_context.User.FirstOrDefault(x=>x.UserName.Equals(user.UserName)&&x.Password.Equals(user.Password));

                if (account != null)
                {
                    throw new Exception("This account is already created");
                }
                User nUser = new User
                {
                    UserName = user.UserName,
                    FullName = user.FullName,
                    Password = CommonData.CommonFunction.GetHashString(user.Password),
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    Gender = user.Gender,
                    Role = user.Role,   
                };
               
                account=_worker.userRepository.AddUser(nUser);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, account.UserName),
                    new Claim(ClaimTypes.Role,account.Role),
                };

                var claimsIndetity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties { };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIndetity), authProperties);
                _worker.userRepository.SaveChanges();
                return RedirectToAction("Index","Home");   
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult SignUp()
        {
            return View();
        }



        public async Task<IActionResult> ShowOrdered()
        {
            var user = _context.User.Where(x => x.UserName.Equals(User.Identity.Name)).FirstOrDefault();
            var order= await _context.Order
                .Include(o => o.OrderDetails)
                .ThenInclude(orderDetail => orderDetail.Product)
                .Include(x=>x.Payment)
                .Where(o => o.CustomerId == user.Id)
                .ToListAsync();

            return View(order);
        }


    }
}
