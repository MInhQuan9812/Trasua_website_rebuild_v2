using Microsoft.EntityFrameworkCore;
using trasua_web_mvc.Dtos;
using trasua_web_mvc.Infracstructures.Entities;
using trasua_web_mvc.Repositories;

namespace trasua_web_mvc.Infracstructures.Strategy
{
    public class DirectPaymentStrategy:IStrategy
    {
        private Worker _worker;
        private readonly TraSuaContext _context;
        private readonly IConfiguration _configuration;

        public DirectPaymentStrategy(TraSuaContext context, IConfiguration configuration)
        {
            _worker = new Worker(context, configuration);
            _context = context;
        }

        public async Task<bool> Paymention(int userId, CheckoutDto checkoutDto)
        {
            try
            {
                await _worker.cartRepository.CheckOut(userId, checkoutDto);
                return true;
            }catch (Exception ex)
            {
                return false;
            }
            
        }
        public async Task<string> GetApprovalUrl()
        {
            return null;
        }

    }
}
