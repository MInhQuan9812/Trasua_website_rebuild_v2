using trasua_web_mvc.Infracstructures.Entities;
using trasua_web_mvc.Infracstructures;

namespace trasua_web_mvc.Repositories
{
    public class PaymentRepository
    {
        private readonly TraSuaContext _context;

        public PaymentRepository(TraSuaContext context)
        {
            _context = context;
        }

        public void AddProduct(Payment payment)
        {
            _context.Payment.Add(payment);
        }

        public IQueryable<Payment> AllPayment()
        {
            IQueryable<Payment> query = _context.Payment.AsQueryable();
            return query;
        }

        //public void DeleteProduct(Payment payment)
        //{
        //    _context.Product.Remove(payment);
        //}


        public void UpdatePayment(Payment payment)
        {
            _context.Entry(payment).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public Payment FindById(int id)
        {
            return _context.Payment.Find(id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
