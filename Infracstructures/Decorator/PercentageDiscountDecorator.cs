namespace trasua_web_mvc.Infracstructures.Decorator
{
    public  class PercentageDiscountDecorator : DiscountDecorator
    {
        private readonly long _discountPercentage;

        public PercentageDiscountDecorator(IOrder order,long discountPercentage) : base(order) 
        {
            _discountPercentage=discountPercentage;
        }

        public long? GetTotalPrice()
        {
            return base.GetTotalPrice() * (1 - _discountPercentage / 100);
        }
    }
}
