using trasua_web_mvc.Infracstructures.Contant;

namespace trasua_web_mvc.Dtos
{
    public class EditUserDto
    {
        public string UserName { get; set; }
        public string FullName { get; set; }

        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }

        public string Password { get; set; }

        public IFormFile? Avatar_Upload { get; set; }

        public string? Avatar { get; set; }

        public int Gender { get; set; } = Contants.Male;

        public string Role { get; set; }
    }
}
