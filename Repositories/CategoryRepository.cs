using trasua_web_mvc.Infracstructures.Entities;
using trasua_web_mvc.Infracstructures;

namespace trasua_web_mvc.Repositories
{
    public class CategoryRepository
    {
        private readonly TraSuaContext _context;

        public CategoryRepository(TraSuaContext context)
        {
            _context = context;
        }

        public void AddCategory(Category category)
        {
            _context.Category.Add(category);
        }

        public IQueryable<Category> AllCategory()
        {
            IQueryable<Category> query = _context.Category.AsQueryable();
            return query;
        }

        public void DeleteCategory(Category category)
        {
            _context.Category.Remove(category);
        }

        public void UpdateCategory(Category category)
        {
            _context.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public Category FindById(int id)
        {
            return _context.Category.Find(id);
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
