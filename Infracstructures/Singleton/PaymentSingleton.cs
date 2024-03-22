using trasua_web_mvc.Infracstructures.Entities;

namespace trasua_web_mvc.Infracstructures.Singleton
{
    public class PaymentSingleton
    {
        public static PaymentSingleton _instance;
        public List<Payment> listPayments = new List<Payment>();

        public PaymentSingleton()
        {

        }

        public static PaymentSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PaymentSingleton();
                }
                return _instance;
            }
        }

        public void GetPaymentList(TraSuaContext context)
        {
            if (listPayments.Count == 0)
            {
                var categories = context.Payment.AsQueryable().ToList();
                foreach (var category in categories)
                {
                    listPayments.Add(category);
                }
            }
        }
    }
}
