using epl.api.Models;
using epl.core.Domain;
using epl.core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace epl.api.Controllers
{
    [Route("api/account/{accountId}/[controller]")]
    public class PersonController : BaseController
    {
        private readonly IAsyncRepository<Person> repository;
        private readonly IAsyncRepository<Account> accountRepository;

        public PersonController(IAsyncRepository<Person> repository,
                                IAsyncRepository<Account> accountRepository)
        {
            this.repository = repository;
            this.accountRepository = accountRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create(string accountId, [FromBody] PersonModel model)
        {
            if (!ModelState.IsValid)
                return Problem();

            var person = new Person()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                DateOfBirth = model.DateOfBirth
            };

            await repository.Add(person);
            var account = await accountRepository.Get(accountId);
            account.Person = person;

            await accountRepository.Update(account);

            return Ok(person);
        }

        [Route("api/[controller]")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] PersonModel model)
        {
            if (!ModelState.IsValid)
                return Problem();

            var person = await repository.Get(model.Id);
            person.FirstName = model.FirstName;
            person.LastName = model.LastName;
            person.DateOfBirth = model.DateOfBirth;

            await repository.Update(person);

            return Ok();
        }
    }
}