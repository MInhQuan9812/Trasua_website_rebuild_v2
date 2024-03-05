using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace trasua_web_mvc.Dtos
{
    public class CreateProductDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        
        public int CategoryId { get; set; }
        public string? Thumbnail_string { get; set; }

        public int Price { get; set; }

        public List<SelectListItem>? Categories { get; set; }
        public IFormFile? Thumbnail { get; set; }




    }
}
