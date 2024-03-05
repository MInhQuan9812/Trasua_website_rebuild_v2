using trasua_web_mvc.Infracstructures;

namespace trasua_web_mvc.Repositories
{
    public class Worker
    {
        private readonly TraSuaContext _context;
        private UserRepository _userRepository;
        private ProductRepository _productRepository;
        private CategoryRepository _categoryRepository;
        private CartRepository _cartRepository;
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
                if (_productRepository == null)
                {
                    if (_context != null)
                    {
                        _productRepository = new ProductRepository(_context);
                    }
                }
                return _productRepository;
            }
        }

        public CategoryRepository categoryRepository
        {
            get
            {
                if (_categoryRepository == null)
                {
                    if (_context != null)
                    {
                        _categoryRepository = new CategoryRepository(_context);
                    }
                }
                return _categoryRepository;
            }
        }

        public CartRepository cartRepository
        {
            get
            {
                if (_cartRepository == null)
                {
                    if (_context != null)
                    {
                        _cartRepository = new CartRepository(_context);
                    }
                }
                return _cartRepository;

            }
        }


    }
}
