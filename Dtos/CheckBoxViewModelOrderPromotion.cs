namespace trasua_web_mvc.Dtos
{
    public class CheckBoxViewModelOrderPromotion 
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string  Value { get; set; }
        public int Price { get; set; }
        public CheckBoxViewModelOrderPromotion() { }

        public CheckBoxViewModelOrderPromotion(int id, string text, string value, int price)
        : this()
        {
            Id = id;
            Text = text;
            Value = value;
            Price = price;
        }
    }
}
