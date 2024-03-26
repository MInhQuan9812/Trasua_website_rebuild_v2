using trasua_web_mvc.Dtos;

namespace trasua_web_mvc.Infracstructures.TemplateMethod
{
    public abstract class OrderTemplateMethod
    {
        public void OrderStep()
        {
            AddItem();
            RemoveItem();
            Checkout();
        }

        protected abstract void AddItem();
        protected abstract void RemoveItem();
        protected abstract void Checkout();
        protected virtual void CheckOutWithPaypal() { }
    }
}
