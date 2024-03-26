using trasua_web_mvc.Infracstructures.Entities;
using trasua_web_mvc.Repositories;

namespace trasua_web_mvc.Infracstructures.Composite
{
    public class SearchName:ISearchComposite
    {
        private readonly List<Product> _products;
        private readonly TraSuaContext _context;
        public SearchName(List<Product> products)
        {
            _products = products;
        }

        public List<Product> Search(string? keyword, int? categoryId, int? minPrice, int? maxPrice)
        {
            return _products.Where(p => p.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }

}
