namespace trasua_web_mvc.Infracstructures.Decorator
{
    public abstract class DiscountDecorator : IOrder
    {
        protected IOrder _order;

        public DiscountDecorator(IOrder order)
        {
            _order= order;
        }

        public virtual long? GetTotalPrice()
        {
            return _order.GetTotalPrice();
        }
    }
}
