using trasua_web_mvc.Infracstructures.Entities;

namespace trasua_web_mvc.Infracstructures.Singleton
{
    public class PromotionSingleton
    {
        public static PromotionSingleton _instance;
        public List<Promotion> listPromotions = new List<Promotion>();

        public PromotionSingleton()
        {

        }

        public static PromotionSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PromotionSingleton();
                }
                return _instance;
            }
        }

        public void GetPromotionList(TraSuaContext context)
        {
            if (listPromotions.Count == 0)
            {
                var promotions = context.Promotion.AsQueryable().ToList();
                foreach (var promotion in promotions)
                {
                    listPromotions.Add(promotion);
                }
            }
        }
        public void ClearData()
        {
            _instance = null;
        }
    }
}
