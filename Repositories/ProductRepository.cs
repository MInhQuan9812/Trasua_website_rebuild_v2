using Microsoft.Extensions.Hosting;
using trasua_web_mvc.Infracstructures;
using trasua_web_mvc.Infracstructures.Entities;

namespace trasua_web_mvc.Repositories
{
    public class ProductRepository
    {
        private readonly TraSuaContext _context;

        public ProductRepository(TraSuaContext context)
        {
            _context = context;
        }

        public void AddProduct(Product product)
        {
            _context.Product.Add(product);
        }

        public IQueryable<Product> AllProduct()
        {
            IQueryable<Product> query = _context.Product.AsQueryable();
            return query;
        }

        public void DeleteProduct(Product product)
        {
            _context.Product.Remove(product);
        }

        public void UpdateProduct(Product product)
        {
            _context.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public Product FindById(int id)
        {
            return _context.Product.Find(id);
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
