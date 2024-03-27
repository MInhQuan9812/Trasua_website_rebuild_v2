using Microsoft.AspNetCore.Mvc.Rendering;
using trasua_web_mvc.Infracstructures.Entities;

namespace trasua_web_mvc.Dtos
{
    public class CheckoutDto
    {
        public string FullName {  get; set; }
        public string PhoneNumber {  get; set; }
        public DateTime Created { get; set; }=DateTime.Now;
        public string? Address { get; set; } = "Ho Chi Minh";
        public int PaymentId { get; set; }
        public int CartId { get; set; }

        public int PromotionId { get; set; }
        public int Total { get; set; }

        public List<CheckBoxViewModelOrderPromotion>? PromotionApplies { get; set; }

        public List<SelectListItem>? PaymentMethods { get; set; }
        public List<CartItem>? CartItems { get; set; }
    }
}
