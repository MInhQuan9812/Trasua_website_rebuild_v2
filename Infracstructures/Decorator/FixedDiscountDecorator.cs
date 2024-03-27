namespace trasua_web_mvc.Infracstructures.Decorator
{
    public class FixedDiscountDecorator : DiscountDecorator
    {
        private readonly long _discountFixed;

        public FixedDiscountDecorator(IOrder order, long discountFixed) : base(order)
        {
            _discountFixed = discountFixed;
        }
        public long? GetTotalPrice()
        {
            return base.GetTotalPrice() - _discountFixed;
        }
    }
}
