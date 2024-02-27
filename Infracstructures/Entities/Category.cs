using System.ComponentModel.DataAnnotations;

namespace trasua_web_mvc.Infracstructures.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Product> Product { get; set; } = new List<Product>();
    }
}
