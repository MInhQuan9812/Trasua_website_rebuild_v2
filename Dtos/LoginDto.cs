using System.ComponentModel.DataAnnotations;

namespace trasua_web_mvc.NewFolder
{
    public class LoginDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
