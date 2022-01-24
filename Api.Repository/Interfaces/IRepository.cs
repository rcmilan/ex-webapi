using Api.Domain.Models;

namespace Api.Repository.Interfaces
{
    public interface IRepository<T, ID> where T : BaseModel<ID>
    {
        T Add(T entity);

        IEnumerable<T> Add(IEnumerable<T> entities);

        T? Get(ID ID);

        IEnumerable<T> Get(Func<T, bool> predicate);

        IEnumerable<T> GetAll(bool onlyActive = true);

        int Remove(ID ID);

        int Remove(Func<T, bool> predicate);
    }
}