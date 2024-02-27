using trasua_web_mvc.Infracstructures;
using trasua_web_mvc.Infracstructures.Entities;

namespace trasua_web_mvc.Repositories
{
    public class UserRepository
    {
        private readonly TraSuaContext _context;

        public UserRepository(TraSuaContext context)
        {
            _context = context;
        }

        public User AddUser(User user)
        {
            return _context.User.Add(user).Entity;
        }

        public void DeleteUser(User user)
        {
            _context.User.Remove(user);
        }

        public void UpdateUser(User user)
        {
            _context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public User FindById(int id)
        {
            return _context.User.Find(id);
        }
        public User FindByUsername(string user)
        {
            User u = _context.User.Where(x => x.FullName == user).FirstOrDefault();
            return u;
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
