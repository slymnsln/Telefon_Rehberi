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
                FirstName = "TestFirstName2",
                LastName = "TestLastName2",
                CompanyName = "TestCompanyName2"
            };

            var result = personManager.Add(person);

            Assert.True(result.Success);
        }

        [Fact]
        public void PersonDelete()
        {
            var personManager = new PersonManager(new EfPersonDal());

            var personId = 2;

            var result = personManager.Delete(personId);

            Assert.True(result.Success);
        }
    }
}
