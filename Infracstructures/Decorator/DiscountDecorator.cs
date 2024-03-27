namespace trasua_web_mvc.Infracstructures.Decorator
{
    public abstract class DiscountDecorator : IOrder
    {
        protected readonly IOrder _order;

        public DiscountDecorator(IOrder order)
        {
            _order= order;
        }

        public virtual long? GetTotalPrice => _order.GetTotalPrice;
    }
}
