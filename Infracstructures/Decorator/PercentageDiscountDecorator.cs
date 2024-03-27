namespace trasua_web_mvc.Infracstructures.Decorator
{
    public  class PercentageDiscountDecorator : DiscountDecorator
    {
        private readonly long _discountPercentage;

        public PercentageDiscountDecorator(IOrder order,long discountPercentage) : base(order) 
        {
            _discountPercentage=discountPercentage;
        }

        public override long? GetTotalPrice
        {
            get
            {
                if (base.GetTotalPrice.HasValue && _discountPercentage!=null)
                {
                    double discount = _discountPercentage / 100.0;
                    return (long)(base.GetTotalPrice.Value * (1 - discount));
                }
                else
                {
                    // Trả về null hoặc giá trị mặc định tùy thuộc vào logic của bạn
                    return base.GetTotalPrice;
                }
            }
        }

    }
}
