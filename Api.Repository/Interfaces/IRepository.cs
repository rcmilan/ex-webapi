using Api.Domain.Models;

namespace Api.Repository.Interfaces
{
    public interface IRepository<TEntity, TID> where TEntity : BaseModel<TID>
    {
        TEntity Add(TEntity entity);

        IEnumerable<TEntity> Add(IEnumerable<TEntity> entities);

        TEntity? Get(TID ID);

        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);

        IEnumerable<TEntity> GetAll(bool onlyActive = true);

        int Remove(TID ID);

        int Remove(Func<TEntity, bool> predicate);
    }
}