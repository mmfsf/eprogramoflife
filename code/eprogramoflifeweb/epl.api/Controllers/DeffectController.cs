using epl.core.Domain;
using epl.core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace epl.api.Controllers
{
    [Authorize]
    [Route("api/programoflife/{programoflifeid}/[controller]")]
    public class DeffectController : BaseController
    {
        private readonly IRepository<Deffects> repository;

        public DeffectController(IRepository<Deffects> repository)
        {
            this.repository = repository;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int ID)
        {
            var deffect = repository.Get(ID);
            return Ok(deffect);
        }

        [HttpPost]
        public IActionResult Create()
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update()
        {
            return Ok();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public IActionResult Delete(int ID)
        {
            repository.Remove(ID);
            return NoContent();
        }
    }
}