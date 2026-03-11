namespace Apontamento.Domain.Interfaces
{
    public interface Irepository<T> where T : class
    {
        void Save(T entity);
        void Delete(T entity);
        List<T> GetAll();

    }
}