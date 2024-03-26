namespace trasua_web_mvc.Dtos
{
    public class ToppingQueryDto
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }

        public string Thumbnail { get; set; }

        public int Price { get; set; }
        public int OptionValueId { get; set; }
        public int OptionId { get; set; }
        public string OptionValue { get; set; }

        public int OptionPrice { get; set; }

    }
}
