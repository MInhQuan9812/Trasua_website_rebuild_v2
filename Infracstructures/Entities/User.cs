using System.ComponentModel.DataAnnotations;
using trasua_web_mvc.Infracstructures.Contant;

namespace trasua_web_mvc.Infracstructures.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public  string UserName { get; set; }
        public  string FullName { get; set; }

        [MaxLength(Contants.PhoneMaxLength)]
        public string? PhoneNumber {  get; set; }

        [MaxLength(Contants.EmailMaxLength)]
        public string? Email { get; set; }

        [Required]
        public string Password {get; set;}

        [MaxLength(Contant.Contants.AvatarMaxLength)]
        public string? Avatar { get; set;}

        public int Gender { get; set; } = Contants.Male;

        public string Role { get; set; } = "Customer";


        public virtual ICollection<Order> Orders { get; set; }=new List<Order>();

        public virtual Cart Cart { get; set; } = new Cart();

    }
}
