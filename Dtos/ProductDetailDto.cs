using Microsoft.AspNetCore.Mvc.Rendering;
using trasua_web_mvc.Infracstructures.Decorator;

namespace trasua_web_mvc.Dtos
{
    public class ProductDetailDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int? Quantity { get; set; }
        public string Thumbnail { get; set; }

        public int SizeId { get; set; }
        public int IngredientId { get; set; }
        public List<CheckBoxViewModel>? Toppings { get; set; }

        public List<CheckBoxViewModel>? Sizes { get; set; }

        public List<SelectListItem>? Ingredients { get; set; }
       

    }
}