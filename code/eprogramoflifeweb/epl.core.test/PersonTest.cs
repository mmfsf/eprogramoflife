using epl.core.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace epl.core.test
{
    [TestClass]
    public class PersonTest
    {
        private Account account;
        private Person person;

        [TestInitialize]
        public void Setup()
        {
            account = new Account(1, "a@b.c", "159753");
            person = new Person(account);
        }

        [TestMethod]
        public void Program_Create()
        {
            var program = person.CreateProgram();

            Assert.IsNotNull(program);
            Assert.IsNotNull(program.Person);
            Assert.IsTrue(program.Person.ID == person.ID);
        }

        [TestMethod]
        public void Program_Call_Create_Multiple_Times_Return_Same_Reference()
        {
            var program_1 = person.CreateProgram();
            program_1.ID = 1;
            var program_2 = person.CreateProgram();

            
            Assert.IsTrue(program_1.ID == program_2.ID);
        }
    }
}
