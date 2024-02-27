using System.ComponentModel.DataAnnotations;

namespace trasua_web_mvc.Infracstructures.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime Created { get; set; }
        public string Address { get; set; }
        public string PaymentStatus { get; set; }
        public long Total { get; set; }
        public int PromotionId { get; set; }


        public virtual User Customer { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
        public virtual Promotion Promotion { get; set; }

    }
}
