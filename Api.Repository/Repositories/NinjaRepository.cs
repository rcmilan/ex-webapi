using Api.Domain.Models;


// Model User
// Dto user

// 2 classes com o mesmo nome

//opção 1 renomear
// User
// UserDto

// opção 2 usar o namespace

// Model.User
// Dto.User


namespace Api.Repository.Repositories
{
    public class NinjaRepository : Interfaces.IRepository<Ninja, int>
    {
        public Ninja Add(Ninja entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ninja> Add(IEnumerable<Ninja> entities)
        {
            throw new NotImplementedException();
        }

        public Ninja? Get(int ID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ninja> Get(Func<Ninja, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ninja> GetAll(bool onlyActive = true)
        {
            throw new NotImplementedException();
        }

        public int Remove(int ID)
        {
            throw new NotImplementedException();
        }

        public int Remove(Func<Ninja, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
