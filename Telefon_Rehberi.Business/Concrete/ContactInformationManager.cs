using Telefon_Rehberi.Business.Abstract;
using Telefon_Rehberi.Business.Constants;
using Telefon_Rehberi.Core.Utilities.Results;
using Telefon_Rehberi.DataAccess.Abstract;
using Telefon_Rehberi.Entities.Concrete;

namespace Telefon_Rehberi.Business.Concrete
{
    public class ContactInformationManager : IContactInformationService
    {
        private readonly IContactInformationDal _contactInformationDal;
        public ContactInformationManager(IContactInformationDal contactInformationDal)
        {
            _contactInformationDal= contactInformationDal;
        }

        public IResult Add(ContactInformation contactInformation)
        {
            if (contactInformation == null)
                return new ErrorResult(Messages.ContactInformationEmpty);

            _contactInformationDal.Add(contactInformation);

            return new SuccessResult(Messages.ContactInformationAdd);
        }

        public IResult Delete(int contactId)
        {
            var contactInformation = _contactInformationDal.Get(x => x.Id == contactId);
            if (contactInformation == null)
                return new ErrorResult(Messages.ContactInformationNull);

            _contactInformationDal.Delete(contactInformation);

            return new SuccessResult(Messages.ContactInformationDelete);
        }

        public IDataResult<IList<ContactInformation>> GetListByPersonId(int personId)
        {
            var contactInformationList = _contactInformationDal.GetList(x => x.PersonUUID == personId);
            if (contactInformationList == null)
                return new ErrorDataResult<IList<ContactInformation>>(Messages.ContactInformationNull);

            return new SuccessDataResult<IList<ContactInformation>>(contactInformationList, Messages.ContactInformationList);
        }
    }
}
