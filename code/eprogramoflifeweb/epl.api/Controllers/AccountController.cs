using epl.api.Models;
using Microsoft.AspNetCore.Mvc;

namespace epl.api.Controllers
{
    public class AccountController : BaseController
    {
        [HttpPost]
        public IActionResult Create(AccountModel model)
        {
            if (!ModelState.IsValid)
                return Problem();

            return Ok();
        }
    }
}