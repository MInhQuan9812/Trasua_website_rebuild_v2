using trasua_web_mvc.Repositories;

namespace trasua_web_mvc.Infracstructures.Observer
{
    public class NotityService : IObserver
    {
        public void Update(ISubject subject)
        {
            if ((subject as CartRepository).State > 0)
            {
               (subject as CartRepository).AlertMessage="Giỏ hàng đã được thêm vào " + (subject as CartRepository).State.ToString() + " sản phẩm"; ;
            }
        }

    }
}
