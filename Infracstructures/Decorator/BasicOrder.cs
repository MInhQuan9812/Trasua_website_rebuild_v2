namespace trasua_web_mvc.Infracstructures.Decorator
{
    public class BasicOrder:IOrder
    {
        public string GetName()
        {
            return "Trà Sữa";
        }

        public string GetDescription()
        {
            return "";
        }
        public int GetPrice()
        {
            return 1;
        }
    }
}
