using Telefon_Rehberi.Business.Concrete;
using Telefon_Rehberi.Core.Utilities.Results;
using Telefon_Rehberi.DataAccess.Concrete;
using Telefon_Rehberi.Entities.Concrete;
using Telefon_Rehberi.Entities.DTOs;

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
                FirstName = "TestFirstName4",
                LastName = "TestLastName4",
                CompanyName = "TestCompanyName4"
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

        [Fact]
        public void GetList()
        {
            var personManager = new PersonManager(new EfPersonDal());

            var result = personManager.GetAll();

            Assert.IsType<List<Person>>(result.Data);
            Assert.True(result.Success);
        }

        [Fact]
        public void GetLocationAllReports()
        {
            var personManager = new PersonManager(new EfPersonDal());

            var result = personManager.GetLocationAllReports();

            Assert.IsType<List<ReportByLocationDto>>(result);
        }
    }
}
