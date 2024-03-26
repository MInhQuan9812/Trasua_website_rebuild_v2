using trasua_web_mvc.Infracstructures.Entities;

namespace trasua_web_mvc.Infracstructures.Composite
{
    public class CompositeSearch
    {
        private readonly List<ISearchComposite> _searchComposite;

        public CompositeSearch()
        {
            _searchComposite = new List<ISearchComposite>();
        }

        public void AddComponent(ISearchComposite searchComposite)
        {
            _searchComposite.Add(searchComposite);
        }

        public List<Product> Search(string? keyword, int? categoryId, int? minPrice, int? maxPrice)
        {
            List<Product> results = new List<Product>();
            foreach (var searchItem in _searchComposite)
            {                          
                   results.AddRange(searchItem.Search(keyword, categoryId, minPrice, maxPrice));            
            }
            return results;
        }
    }
}
