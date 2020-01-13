using epl.core.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace epl.api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class PersonController : BaseController
    {
        [HttpPost]
        public IActionResult Create([FromBody] Person person)
        {
            return Ok();
        }
    }
}