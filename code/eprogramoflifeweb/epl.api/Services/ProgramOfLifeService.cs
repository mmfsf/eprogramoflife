using epl.api.Models;
using epl.core.Domain;
using epl.core.Interfaces;
using System;

namespace epl.api.Services
{
    public class ProgramOfLifeService
    {
        private readonly IRepository<ProgramOfLife> programOfLifeRepository;
        private readonly IRepository<Person> personRepository;

        public ProgramOfLifeService(IRepository<ProgramOfLife> programOfLifeRepository,
                                    IRepository<Person> personRepository)
        {
            this.programOfLifeRepository = programOfLifeRepository;
            this.personRepository = personRepository;
        }

        public void Create(ProgramOfLifeModel model)
        {
            var person = personRepository.Get(model.PersonId);
            if (person is null)
            {
                throw new ArgumentNullException();
            }

            var program = new ProgramOfLife(person)
            {
                Name = model.Name,
                Motto = model.Motto,
                Ideal = model.Ideal,
                Virtue = model.Virtue,
                Means = model.Path
            };

            programOfLifeRepository.Add(program);
        }
    }
}
