using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace trasua_web_mvc.Infracstructures.Entities
{
    [Index(nameof(OrderId), IsUnique = false)]
    public class OrderDetail
    {
        //Mã
        [Key]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }
        public int TotalPrice { get; set; }


        public virtual Order Order { get; set; }
        public Product Product { get; set; }

    }
}
