using Microsoft.AspNetCore.Mvc;

namespace epl.api.Controllers
{
    public class ProgramController : BaseController
    {
        [HttpGet]
        public IActionResult Get()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            return View();
        }
    }
}