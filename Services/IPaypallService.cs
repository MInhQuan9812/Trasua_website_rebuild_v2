
using PayPal.Api;

namespace trasua_web_mvc.Services
{
    public interface IPaypallService
    {
        Task<Payment> CreateOrderAsync(int amount, string returnUrl, string cancleUrl);
    }
}
