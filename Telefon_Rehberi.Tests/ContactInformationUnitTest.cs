using Telefon_Rehberi.Business.Concrete;
using Telefon_Rehberi.DataAccess.Concrete;
using Telefon_Rehberi.Entities.Concrete;

namespace Telefon_Rehberi.Tests
{
    public class ContactInformationUnitTest
    {
        [Fact]
        public void ContactInformationAdd()
        {
            var contactInformationManager = new ContactInformationManager(new EfContactInformationDal());

            var contactInformation = new ContactInformation
            {
                PersonUUID = 4,
                Phone = "TestPhone2",
                Email = "TestEmail2",
                Location = "TestLocation2"
            };

            var result = contactInformationManager.Add(contactInformation);

            Assert.True(result.Success);
        }

        [Fact]
        public void ContactInformationDelete()
        {
            var contactInformationManager = new ContactInformationManager(new EfContactInformationDal());

            var contactInformationId = 1;

            var result = contactInformationManager.Delete(contactInformationId);

            Assert.True(result.Success);
        }

        [Fact]
        public void GetListByPersonId()
        {
            var contactInformationManager = new ContactInformationManager(new EfContactInformationDal());

            var result = contactInformationManager.GetListByPersonId(2);

            Assert.IsType<List<ContactInformation>>(result.Data);
            Assert.True(result.Success);
        }

    }
}
