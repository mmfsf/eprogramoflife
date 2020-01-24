using epl.api.Models;
using epl.core.Domain;
using epl.core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace epl.api.Controllers
{
    [Authorize]
    [Route("api/account/{accountid}/[controller]")]
    public class PersonController : BaseController
    {
        private readonly IRepository<Account> accountRepository;
        private readonly IRepository<Person> repository;

        public PersonController(IRepository<Person> repository, IRepository<Account> accountRepository)
        {
            this.repository = repository;
            this.accountRepository = accountRepository;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int ID)
        {
            var person = repository.Get(ID);
            return Ok(person);
        }

        [HttpPost]
        public IActionResult Create([FromBody] PersonModel model)
        {
            if (!ModelState.IsValid)
                return Problem();

            var person = new Person(accountRepository.Get(model.AccountID))
            { 
                FirstName = model.FirstName,
                LastName = model.LastName,
                DateOfBirth = model.DateOfBirth
            };
            repository.Add(person);

            return Ok(person);
        }

        [HttpPut]
        public IActionResult Update([FromBody] PersonModel model)
        {
            if (!ModelState.IsValid)
                return Problem();

            var person = repository.Get(model.ID);
            person.FirstName = model.FirstName;
            person.LastName = model.LastName;
            person.DateOfBirth = model.DateOfBirth;

            repository.Update(person);

            return Ok();
        }
    }
}