using trasua_web_mvc.Infracstructures;
using trasua_web_mvc.Services;

namespace trasua_web_mvc.Repositories
{
    public class Worker
    {
        private readonly IConfiguration _configuration;
        private readonly TraSuaContext _context;
        private UserRepository _userRepository;
        private ProductRepository _productRepository;
        private CategoryRepository _categoryRepository;
        private CartRepository _cartRepository;
        private PaymentRepository _paymentRepository;
        public Worker(TraSuaContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public UserRepository userRepository
        {
            get
            {
                if (_userRepository == null)
                {

                    _userRepository = new UserRepository(_context);

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

                    _productRepository = new ProductRepository(_context);

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

                    _categoryRepository = new CategoryRepository(_context);

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

                    _cartRepository = new CartRepository(_context, _configuration);

                }
                return _cartRepository;

            }
        }

        public PaymentRepository paymentRepository
        {
            get
            {
                if (_paymentRepository == null)
                {

                    _paymentRepository = new PaymentRepository(_context);

                }
                return _paymentRepository;

            }
        }




    }
}
