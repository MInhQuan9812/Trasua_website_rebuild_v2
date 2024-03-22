using trasua_web_mvc.Infracstructures.Entities;

namespace trasua_web_mvc.Infracstructures.Singleton
{
    public class CategorySingleton
    {
        public static CategorySingleton _instance;

        public List<Category> listCategories=new List<Category>();

        public CategorySingleton()
        {
            
        }

        public static CategorySingleton Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new CategorySingleton();
                }
                return _instance;
            }
        }

        public void GetCategoryList(TraSuaContext context)
        {
            if(listCategories.Count == 0)
            {
                var categories = context.Category.AsQueryable().ToList();

                foreach(var category in categories)
                {
                    listCategories.Add(category);
                }
            }
        }
    }
}
