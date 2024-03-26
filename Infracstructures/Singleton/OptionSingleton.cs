using Microsoft.EntityFrameworkCore;
using trasua_web_mvc.Dtos;
using trasua_web_mvc.Infracstructures.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace trasua_web_mvc.Infracstructures.Singleton
{
    public class OptionSingleton
    {
        private static readonly TraSuaContext _context;
        public static OptionSingleton _instance;
        public List<ProductOptionValue> listTopping;
        public List<ProductOptionValue> listSize;
        public List<ProductOptionValue> listIngredient;

        public OptionSingleton()
        {
            listTopping = new List<ProductOptionValue>();
            listSize = new List<ProductOptionValue>();
            listIngredient= new List<ProductOptionValue>();
        }

        public static OptionSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new OptionSingleton();
                }
                return _instance;
            }
        }

        public void GetIngredientList(TraSuaContext context,int productId)
        {
            if (listIngredient.Count == 0)
            {
                var ingredients = context.ProductOptionValue
                    .Include(x => x.OptionValue)
                    .ThenInclude(x => x.Option)
                    .ToList()
                    .Where(x => x.ProductId == productId && x.OptionId == 3);

                foreach (var topping in ingredients)
                {
                    listIngredient.Add(topping);
                }
            }
        }


        public void GetToppingList(TraSuaContext context, int productId)
        {
            if (listTopping.Count == 0)
            {
                var toppings = context.ProductOptionValue.Include(x => x.Product)
                    .Include(x => x.OptionValue)
                    .Where(x => x.ProductId.Equals(productId) && x.OptionId.Equals(2)).ToList();
                
                foreach (var topping in toppings)
                {
                    listTopping.Add(topping);
                }
            }
        }

        public void GetSizeList(TraSuaContext context, int productId)
        {
            if (listSize.Count == 0)
            {
                var sizes = context.ProductOptionValue
                    .Include(x => x.Product)
                    .Include(x => x.Option)
                    .Include(x => x.OptionValue)
                    .ToList()
                    .Where(x => x.ProductId == productId && x.OptionId == 1);
                foreach (var size in sizes)
                {
                    listSize.Add(size);
                }
            }
        }
        public void ClearData()
        {
            _instance = null ;
        }
    }
}
