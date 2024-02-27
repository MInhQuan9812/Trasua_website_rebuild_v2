using System.ComponentModel.DataAnnotations;

namespace trasua_web_mvc.Infracstructures.Entities
{
    public class Promotion
    {
        [Key]
        public int Id { get; set; } 

        public string Name { get; set; }

        public int Percentdiscount { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
