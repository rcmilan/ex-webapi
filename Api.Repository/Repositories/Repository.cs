using Api.Domain.Models;
using Api.Repository.Interfaces;

namespace Api.Repository.Repositories
{
    public sealed class Repository<TEntity, TID> : IRepository<TEntity, TID> where TEntity : BaseModel<TID>
    {
        private static readonly List<TEntity> _entities = new();

        public TEntity Add(TEntity entity)
        {
            _entities.Add(entity);

            return entity;
        }

        public IEnumerable<TEntity> Add(IEnumerable<TEntity> entities)
        {
            _entities.AddRange(entities);

            return entities;
        }

        public TEntity? Get(TID ID) => _entities.SingleOrDefault(e => e.ID != null && e.ID.Equals(ID));

        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate) => _entities.Where(e => predicate(e));

        public IEnumerable<TEntity> GetAll(bool onlyActive = true) => onlyActive ? _entities.Where(e => e.IsActive) : _entities;

        public int Remove(TID ID)
        {
            var entity = Get(ID);

            if (entity is not null)
            {
                var index = _entities.IndexOf(entity);

                _entities[index].IsActive = false;

                return 1;
            }

            return 0;
        }

        public int Remove(Func<TEntity, bool> predicate)
        {
            var entities = Get(predicate);

            int count = 0;

            foreach (var entity in entities)
                count += Remove(entity.ID);

            return count;
        }
    }
}