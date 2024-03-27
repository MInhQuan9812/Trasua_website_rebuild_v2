using trasua_web_mvc.Dtos;

namespace trasua_web_mvc.Infracstructures.Strategy
{
    public interface IStrategy
    {
        Task<bool> Paymention(int amount, CheckoutDto checkoutDto);

        Task<string> GetApprovalUrl();
    }
}
