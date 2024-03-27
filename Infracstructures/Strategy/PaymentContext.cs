using trasua_web_mvc.Dtos;

namespace trasua_web_mvc.Infracstructures.Strategy
{
    public class PaymentContext
    {
        private readonly IStrategy _paymentStrategy;

        public PaymentContext(IStrategy paymentStrategy)
        {
            _paymentStrategy = paymentStrategy;
        }

        public Task<bool> ProcessOrderPayment(int userId,CheckoutDto checkoutDto)
        {
            return _paymentStrategy.Paymention(userId,checkoutDto);
        }
    }
}
