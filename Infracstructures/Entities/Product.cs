using System.ComponentModel.DataAnnotations;

namespace trasua_web_mvc.Infracstructures.Entities
{
    public interface ProductPrototype
    {
        ProductPrototype Clone();
    }

    public class Product : ProductPrototype
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int Price { get; set; }
        public string Thumbnail { get; set; }


        //public virtual OrderDetail OrderDetail { get; set; }
        public virtual Category Category { get; set; }
        public virtual CartItem CartItem { get; set; }


        public ProductPrototype Clone()
        {
            Product product = new Product();
            product.Name=Name;
            product.Price=Price;
            product.Description = Description;
            product.CategoryId = CategoryId;
            product.Thumbnail=Thumbnail;
            return product;
        }
    }
}
