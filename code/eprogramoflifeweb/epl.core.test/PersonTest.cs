using epl.core.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace epl.core.test
{
    [TestClass]
    public class PersonTest
    {
        private Account account;

        [TestInitialize]
        public void Setup()
        {
            account = new Account(1, "a@b.c", "159753");
        }

        [TestMethod]
        public void New_Person_Have_Age()
        {
            var person = new Person(account);

            Assert.IsNotNull(person.Age);
        }
    }
}
