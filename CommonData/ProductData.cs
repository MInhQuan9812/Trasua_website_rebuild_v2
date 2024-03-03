using Microsoft.AspNetCore.Mvc.Rendering;
using trasua_web_mvc.Infracstructures;
using trasua_web_mvc.Repositories;

namespace trasua_web_mvc.CommonData
{
    public static class ProductData
    {
        private static TraSuaContext _context;

        public static List<SelectListItem> getCategoryList(TraSuaContext context)
        {
            _context = context;
            Worker _worker = new Worker(_context);
            List<SelectListItem> lstCategory = _worker.categoryRepository.AllCategory().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString(), }).ToList();
            return lstCategory;
        }
    }
}
