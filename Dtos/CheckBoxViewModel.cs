using static System.Net.Mime.MediaTypeNames;

namespace trasua_web_mvc.Dtos
{
    public class CheckBoxViewModel
    {
        public int Id { get; set; }
        public string LabelName { get; set; }
        public bool IsChecked { get; set; }
        public int Price { get;set; }
        public CheckBoxViewModel() { }

        public CheckBoxViewModel(int id,string labelName, bool isChecked, int price)
        : this()
        {
            Id = id;
            LabelName = labelName;
            IsChecked = isChecked;
            Price = price;
        }
    }
}
