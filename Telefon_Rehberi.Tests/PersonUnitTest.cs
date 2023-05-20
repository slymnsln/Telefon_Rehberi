using Telefon_Rehberi.Business.Concrete;
using Telefon_Rehberi.DataAccess.Concrete;
using Telefon_Rehberi.Entities.Concrete;

namespace Telefon_Rehberi.Tests
{
    public class PersonUnitTest
    {
        [Fact]
        public void PersonAdd()
        {
            var personManager = new PersonManager(new EfPersonDal());

            var person = new Person
            {
                FirstName = "TestFirstName1",
                LastName = "TestLastName1",
                CompanyName = "TestCompanyName1"
            };

            var result = personManager.Add(person);

            Assert.True(result.Success);
        }
    }
}
