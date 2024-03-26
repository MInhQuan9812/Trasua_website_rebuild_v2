using System.ComponentModel.DataAnnotations;
using trasua_web_mvc.Infracstructures.Decorator;

namespace trasua_web_mvc.Infracstructures.Entities
{
    public interface ProductPrototype
    {
        ProductPrototype Clone();
    }
    public class Product:ProductPrototype,IProduct
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int Price { get; set; }
        public string? Thumbnail { get; set; }

        //public int IngredientId { get; set; }

        //public virtual OrderDetail OrderDetail { get; set; }
        public virtual Category Category { get; set; }
        public virtual CartItem CartItem { get; set; }

        public virtual ICollection<ProductOptionValue> ProductOptionValues { get; set; }=new List<ProductOptionValue>();

        //public virtual ProductIngredient Ingredient { get; set; }
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

        public string GetName()
        {
            return Name;
        }

        public int GetPrice()
        {
            return Price;
        }

        public string GetDescription()
        {
            return Description;
        }
    }
}
