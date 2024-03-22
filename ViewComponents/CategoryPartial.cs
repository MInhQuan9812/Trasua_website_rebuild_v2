using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using trasua_web_mvc.Infracstructures;
using trasua_web_mvc.Repositories;

namespace trasua_web_mvc.ViewComponents
{
    [ViewComponent(Name="CategoryPartial")]
    public class CategoryPartial:ViewComponent
    {
        private readonly TraSuaContext _context;
        private Worker _worker;
        private readonly IConfiguration _configuration;

        public CategoryPartial(TraSuaContext context,IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
            _worker = new Worker(_context,_configuration);
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categoryList = _worker.categoryRepository.AllCategory();
            return View(categoryList);
        }

    }
}
