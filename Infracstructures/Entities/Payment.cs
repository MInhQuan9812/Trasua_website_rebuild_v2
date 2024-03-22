namespace trasua_web_mvc.Infracstructures.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Amount { get; set; }
        public DateTime PaymentDate { get; set; }

        public virtual ICollection<Order> Orders { get; set; }


    }
}
