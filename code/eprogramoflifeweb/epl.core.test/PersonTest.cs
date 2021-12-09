using epl.core.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace epl.core.test
{
    [TestClass]
    public class PersonTest
    {
        [TestInitialize]
        public void Setup()
        {
        }

        [TestMethod]
        public void New_Person_Have_Age()
        {
            var person = new Person();

            Assert.IsNotNull(person.Age);
        }
    }
}
