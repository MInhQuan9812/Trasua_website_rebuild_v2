namespace trasua_web_mvc.Infracstructures.Observer
{
    public interface ISubject
    {
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        void Notify();

    }
}
