using Microsoft.AspNetCore.Mvc.Rendering;
using trasua_web_mvc.Dtos;
using trasua_web_mvc.Infracstructures;
using trasua_web_mvc.Infracstructures.Entities;
using trasua_web_mvc.Infracstructures.Singleton;
using trasua_web_mvc.Repositories;

namespace trasua_web_mvc.CommonData
{
    public static class ProductData
    {
        private static TraSuaContext _context;

        public static List<SelectListItem> getCategoryList(TraSuaContext context)
        {
            _context = context;
            CategorySingleton.Instance.GetCategoryList(_context);
            List<SelectListItem> lstCategory = CategorySingleton.Instance.listCategories.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString(), }).ToList();
            return lstCategory;
        }

        public static List<CheckBoxViewModel> getToppingList(TraSuaContext context,int productId)
        {
            _context = context;
            OptionSingleton.Instance.GetToppingList(context,productId);
            List<CheckBoxViewModel> lstTopping = OptionSingleton.Instance.listTopping.Select(x => new CheckBoxViewModel { Id = x.Id, LabelName = x.OptionValue.Value,IsChecked=false,Price=x.OptionValue.Price }).ToList();
            return lstTopping;
        } 

        public static List<CheckBoxViewModel> getSizeList(TraSuaContext context,int productId)
        {
            _context = context;
            OptionSingleton.Instance.GetSizeList(context,productId);
            List<CheckBoxViewModel> lstTopping = OptionSingleton.Instance.listSize.Select(x => new CheckBoxViewModel { LabelName = x.OptionValue.Value, Id = x.Id,IsChecked=false,Price=x.OptionValue.Price }).ToList();
            return lstTopping;

        }

        public static List<SelectListItem> getIngredientList(TraSuaContext context, int productId)
        {
            _context = context;
            OptionSingleton.Instance.GetIngredientList(context,productId);
            List<SelectListItem> lstTopping = OptionSingleton.Instance.listIngredient.Select(x => new SelectListItem { Text = x.OptionValue.Value, Value = x.Id.ToString(), }).ToList();
            return lstTopping;

        }
    }
}
