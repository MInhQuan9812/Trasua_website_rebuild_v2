using trasua_web_mvc.Infracstructures.Entities;
using trasua_web_mvc.Infracstructures;

namespace trasua_web_mvc.Repositories
{
    public class PromotionRepository
    {
        private readonly TraSuaContext _context;

        public PromotionRepository(TraSuaContext context)
        {
            _context = context;
        }

        public void AddPromotion(Promotion promotion)
        {
            _context.Promotion.Add(promotion);
        }

        public IQueryable<Promotion> AllPromotion()
        {
            IQueryable<Promotion> query = _context.Promotion.AsQueryable();
            return query;
        }

        public void DeletePromotion(Promotion promotion)
        {
            _context.Promotion.Remove(promotion);
        }

        public void UpdatePromotion(Promotion promotion)
        {
            _context.Entry(promotion).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public Promotion FindById(int id)
        {
            return _context.Promotion.Find(id);
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
