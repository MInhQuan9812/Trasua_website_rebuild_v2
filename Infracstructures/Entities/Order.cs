using System.ComponentModel.DataAnnotations;
using trasua_web_mvc.Infracstructures.Decorator;

namespace trasua_web_mvc.Infracstructures.Entities
{
    public class Order:IOrder
    {
        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime Created { get; set; }
        public string Address { get; set; }
        public int PaymentId { get; set; }
        
        public long? Total { get; set; }
        public int? PromotionId { get; set; } = 0;


        public virtual User Customer { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
        public virtual Promotion Promotion { get; set; }

        public virtual Payment Payment { get; set; }

        public long? GetTotalPrice()
        {
            return Total;
        }
    }
}
