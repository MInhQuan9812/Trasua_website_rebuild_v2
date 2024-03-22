using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using trasua_web_mvc.Infracstructures;
using trasua_web_mvc.Repositories;

namespace trasua_web_mvc.Controllers
{
    public class OrderController:Controller
    {
        private readonly TraSuaContext _context;
        private Worker _worker;
        private readonly IConfiguration _configuration;
        public OrderController(TraSuaContext context,IConfiguration configuration )
        {
            _context = context;
            _configuration = configuration;

            _worker = new Worker(context,_configuration);
        }

 

    }
}
