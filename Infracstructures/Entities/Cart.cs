using Microsoft.Extensions.Configuration.UserSecrets;
using System.ComponentModel.DataAnnotations;

namespace trasua_web_mvc.Infracstructures.Entities
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        public string? CusIdentify { get; set; }

        public DateTime CreateAt { get; set; } = DateTime.Now;

        public DateTime LastUpdate { get; set; } = DateTime.Now;

        public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

        public virtual User Customer { get; set; }

        public Cart(string username)
        {
            CusIdentify=username;
        }
    }
}
