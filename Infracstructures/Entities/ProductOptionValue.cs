namespace trasua_web_mvc.Infracstructures.Entities
{
    public class ProductOptionValue
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int OptionId { get; set; }
        public int OptionValueId { get;  set; }

        public virtual Product Product { get; set; }
        public virtual Option Option { get; set; }
        public virtual OptionValue OptionValue { get; set; }
    }
}
