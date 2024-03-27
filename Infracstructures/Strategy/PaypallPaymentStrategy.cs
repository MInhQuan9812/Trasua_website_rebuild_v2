using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using trasua_web_mvc.Dtos;
using trasua_web_mvc.Infracstructures.Facade;
using trasua_web_mvc.Repositories;

namespace trasua_web_mvc.Infracstructures.Strategy
{
    public class PaypallPaymentStrategy:IStrategy
    {

        private Worker _worker;
        private readonly IConfiguration _configuration;
        public string ApprovalUrl { get;set ; }

        public PaypallPaymentStrategy(TraSuaContext context, IConfiguration configuration)
        {
            _configuration=configuration;
            _worker = new Worker(context, configuration);
        }

        public async Task<bool> Paymention(int userId, CheckoutDto checkoutDto)
        {
            try
            {
                int amount= await _worker.cartRepository.GetTotalCheckout(userId, checkoutDto);
                ApprovalUrl = await PayUsingPaypal(amount);
                await _worker.cartRepository.CheckOut(userId, checkoutDto);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<string> GetApprovalUrl()
        {
            return ApprovalUrl;
        }

        public async Task<string> PayUsingPaypal(int amount)
        {
            try
            {
                string approvalUrl = await ServiceFacade.Instance(_configuration).PaymentWithPaypall(amount);
                if (!string.IsNullOrEmpty(approvalUrl))
                {
                    return approvalUrl;
                }
                else
                {
                    throw new Exception("Error to initial Payment");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }
    }
}
