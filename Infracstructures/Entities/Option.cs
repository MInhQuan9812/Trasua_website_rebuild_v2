namespace trasua_web_mvc.Infracstructures.Entities
{
    public class Option
    {
        public int Id {  get; set; }
        public string Name { get; set; }

        public virtual ICollection<ProductOptionValue> ProductOptionValues { get; set; }
    }
}
