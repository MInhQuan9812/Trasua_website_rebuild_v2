using trasua_web_mvc.Infracstructures.Entities;

namespace trasua_web_mvc.Infracstructures.Composite
{
    public interface ISearchComposite
    {
        List<Product> Search(string? keyword,int? categoryId,int? minPrice,int? maxPrice);
    }
}
