using trasua_web_mvc.Infracstructures.Decorator;

namespace trasua_web_mvc.Infracstructures.Entities
{
    public class OptionValue:IOption
    {
        public int Id { get; set; } 
        public int OptionId { get; set; }
        public string Value { get; set; }
        public int Price { get; set; }  
        public virtual Option Option { get; set; }
        public virtual ICollection<ProductOptionValue> ProductOptionValues { get; set; }

        public string GetName()
        {
            return Value;
        }

        public int GetPrice()
        {
            return Price;
        }
    }
}
