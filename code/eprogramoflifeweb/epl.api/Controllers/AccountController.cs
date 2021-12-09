using epl.api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using epl.core.Domain;
using epl.core.Interfaces;

namespace epl.api.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : BaseController
    {
        private readonly IAsyncRepository<Account> repository;
        public AccountController(IAsyncRepository<Account> repository)
        {
            this.repository = repository;
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(string Id)
        {
            var account = await repository.Get(Id);
            return Ok(account);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AccountModel model)
        {
            if (!ModelState.IsValid)
                return Problem();

            var account = new Account(model.Email, model.Password)
            {
                IsActive = true
            };

            await repository.Add(account);

            return Ok(account);
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