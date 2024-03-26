using System.ComponentModel.DataAnnotations;
using trasua_web_mvc.Infracstructures.Decorator;
using trasua_web_mvc.Infracstructures.Entities;

namespace trasua_web_mvc.Dtos
{
    public class ProductHasOptionCheckoutDto:IProduct
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int Price { get; set; }
        public string? Thumbnail { get; set; }

        public virtual Category Category { get; set; }
        public virtual CartItem CartItem { get; set; }

        public virtual ICollection<ProductOptionValue> ProductOptionValues { get; set; } = new List<ProductOptionValue>();
        public ProductPrototype Clone()
        {
            Product product = new Product()
            {
                Name = Name,
                Description = Description,
                Price = Price,
                Thumbnail = Thumbnail,
                CategoryId = CategoryId,
            };
            return product;
        }

        public string GetDescription()
        {
            return Description;
        }

        public int GetPrice()
        {
            return Price;
        }

        public string GetName()
        {
            return Name;
        }
    }
}
