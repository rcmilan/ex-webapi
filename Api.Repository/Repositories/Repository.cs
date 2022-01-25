using Api.Domain.Models;
using Api.Repository.Interfaces;

namespace Api.Repository.Repositories
{
    public sealed class Repository<T, ID> : IRepository<T, ID> where T : BaseModel<ID>
    {
        private static readonly List<T> _entities = new();

        public T Add(T entity)
        {
            _entities.Add(entity);

            return entity;
        }

        public IEnumerable<T> Add(IEnumerable<T> entities)
        {
            _entities.AddRange(entities);

            return entities;
        }

        public T? Get(ID ID) => _entities.SingleOrDefault(e => e.ID != null && e.ID.Equals(ID));

        public IEnumerable<T> Get(Func<T, bool> predicate) => _entities.Where(e => predicate(e));

        public IEnumerable<T> GetAll(bool onlyActive = true) => onlyActive ? _entities.Where(e => e.IsActive) : _entities;

        public int Remove(ID ID)
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

        public int Remove(Func<T, bool> predicate)
        {
            var entities = Get(predicate);

            int count = 0;

            foreach (var entity in entities)
                count += Remove(entity.ID);

            return count;
        }
    }
}