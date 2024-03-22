using System.ComponentModel.DataAnnotations;

namespace trasua_web_mvc.Infracstructures.Entities
{
    public class CartItem
    {
        [Key]
        public int Id { get; set; }

        public int CartId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; } = 0;

        public  Product Product { get; set; }

        public virtual Cart Cart { get;set; }
    }
}
