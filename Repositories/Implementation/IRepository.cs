namespace trasua_web_mvc.Repositories.Implementation
{
    public interface IRepository<T>
    {
        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Dispose();
    }
}
