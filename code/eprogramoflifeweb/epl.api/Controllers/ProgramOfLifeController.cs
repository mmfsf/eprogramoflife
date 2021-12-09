using epl.api.Models;
using epl.core.Domain;
using epl.core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace epl.api.Controllers
{
    [Authorize]
    [Route("api/person/{personid}/[controller]")]
    public class ProgramOfLifeController : BaseController
    {
        private readonly IRepository<ProgramOfLife> repository;

        public ProgramOfLifeController(IRepository<ProgramOfLife> repository)
        {
            this.repository = repository;
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var program = repository.Get(id);
            return Ok(program);
        }

        [HttpPost]
        public IActionResult Create([FromBody] ProgramOfLifeModel model)
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] ProgramOfLife program)
        {
            repository.Update(program);
            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public IActionResult Delete(string Id)
        {
            repository.Remove(Id);
            return NoContent();
        }
    }
}