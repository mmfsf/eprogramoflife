using epl.api.Models;
using epl.core.Domain;
using epl.core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace epl.api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class ProgramController : BaseController
    {
        private readonly IRepository<ProgramOfLife> repository;

        public ProgramController(IRepository<ProgramOfLife> repository)
        {
            this.repository = repository;
        }

        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult All()
        {
            var list = repository.List();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var program = repository.Get(id);
            return Ok(program);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ProgramOfLifeModel model)
        {
            var person = new Person(new Account(1, string.Empty, string.Empty));
            var program = new ProgramOfLife(person)
            {
                ID = 1,
                Name = model.Name
            };

            repository.Add(program);
            return Ok();
        }

        [HttpPut]
        public IActionResult Put([FromBody] ProgramOfLife program)
        {
            repository.Update(program);
            return Ok();
        }
    }
}