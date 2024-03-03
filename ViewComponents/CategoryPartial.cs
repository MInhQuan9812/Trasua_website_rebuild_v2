using Microsoft.AspNetCore.Mvc;
using trasua_web_mvc.Infracstructures;
using trasua_web_mvc.Repositories;

namespace trasua_web_mvc.ViewComponents
{
    [ViewComponent(Name="CategoryPartial")]
    public class CategoryPartial:ViewComponent
    {
        private readonly TraSuaContext _context;
        private Worker _worker;

        public CategoryPartial(TraSuaContext context)
        {
            _context = context;
            _worker = new Worker(_context);
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categoryList = _worker.categoryRepository.AllCategory();
            return View(categoryList);
        }

    }
}
