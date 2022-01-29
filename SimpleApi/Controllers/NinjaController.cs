using Api.Domain.Models;
using Api.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace SimpleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NinjaController : ControllerBase
    {
        private readonly IRepository<Ninja, int> _repository;

        public NinjaController(IRepository<Ninja, int> repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public ActionResult<Ninja> Post(Ninja ninja)
        {
            _repository.Add(ninja);

            return Ok(ninja);
        }
    }
}
