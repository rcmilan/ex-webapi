using Api.Domain.Models;
using Api.Repository.Interfaces;
using Api.Repository.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace SimpleApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private IRepository<User, Guid> _repository;

        public UserController()
        {
            _repository = new Repository<User, Guid>();
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAll()
        {
            var result = _repository.GetAll();

            if (result.Any())
                return Ok(result);

            return NotFound();
        }

        [HttpPost]
        public ActionResult<User> Add(User user)
        {
            return Ok(_repository.Add(user));
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetById(Guid ID)
        {
            var result = _repository.Get(ID);

            if (result is not null)
                return Ok(result);

            return NotFound();
        }
    }
}
