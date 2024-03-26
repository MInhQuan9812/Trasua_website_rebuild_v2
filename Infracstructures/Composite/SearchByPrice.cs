using trasua_web_mvc.Infracstructures.Entities;

namespace trasua_web_mvc.Infracstructures.Composite
{
    public class SearchByPrice : ISearchComposite
    {
        private readonly List<Product> _products;


        public SearchByPrice(List<Product> products)
        {
            _products = products;
        }

        public List<Product> Search(string? keyword, int? categoryId, int? minPrice, int? maxPrice)
        {

            return _products.Where(p => p.Price >= minPrice && p.Price <= maxPrice).ToList();

        }
    }
}
