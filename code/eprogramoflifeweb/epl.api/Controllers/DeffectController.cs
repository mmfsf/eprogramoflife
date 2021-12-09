using epl.core.Domain;
using epl.core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace epl.api.Controllers
{
    [Authorize]
    [Route("api/programoflife/{programOfLifeId}/[controller]")]
    public class DeffectController : BaseController
    {
        private readonly IAsyncRepository<ProgramOfLife> repository;

        public DeffectController(IAsyncRepository<ProgramOfLife> repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        public IActionResult Create(string programOfLifeId)
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(string programOfLifeId)
        {
            return Ok();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public IActionResult Delete(string programOfLifeId, string Id)
        {
            repository.Remove(Id);
            return NoContent();
        }
    }
}