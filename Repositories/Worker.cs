using trasua_web_mvc.Infracstructures;

namespace trasua_web_mvc.Repositories
{
    public class Worker
    {
        private readonly TraSuaContext _context;
        private UserRepository _userRepository;
        private ProductRepository _productRepository;

        public Worker(TraSuaContext context)
        {
            _context = context;

        }

        public UserRepository userRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    if (_context != null)
                    {
                        _userRepository = new UserRepository(_context);
                    }
                }
                return _userRepository;
            }
        }

        public ProductRepository productRepository
        {
            get
            {
                if(_productRepository == null)
                {
                    if(_context != null)
                    {
                        _productRepository = new ProductRepository(_context);
                    }
                }
                return _productRepository;
            }
        }


    }
}
