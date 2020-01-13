using epl.api.Models;
using epl.core.Domain;
using epl.core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace epl.api.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : BaseController
    {
        private readonly IRepository<Account> repository;

        public AccountController(IRepository<Account> repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        public IActionResult Create(AccountModel model)
        {
            if (!ModelState.IsValid)
                return Problem();

            return Ok();
        }
    }
}