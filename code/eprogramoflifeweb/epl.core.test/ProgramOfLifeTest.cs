using epl.core.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace epl.core.test
{
    [TestClass]
    public class ProgramOfLifeTest
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
        public void ProgramOfLife_Has_No_Null_Objects()
        {
            var program = new ProgramOfLife(person);

            Assert.IsNotNull(program.Means);
            Assert.IsNotNull(program.CreatedDate);
            Assert.IsNotNull(program.Deffects);
        }
    }
}
