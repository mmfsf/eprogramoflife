using epl.api.Models;
using epl.core.Domain;
using epl.core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

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

            var account = new Account(model.Email, model.Password);

            repository.Add(account);
            return Ok(account);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public IActionResult Delete(int ID)
        {
            repository.Remove(ID);
            return NoContent();
        }
    }
}