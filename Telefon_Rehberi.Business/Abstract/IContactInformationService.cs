using Telefon_Rehberi.Core.Utilities.Results;
using Telefon_Rehberi.Entities.Concrete;

namespace Telefon_Rehberi.Business.Abstract
{
    public interface IContactInformationService
    {
        IResult Add(ContactInformation contactInformation);
        IResult Delete(int contactId);
        IDataResult<IList<ContactInformation>> GetListByPersonId(int personId);
    }
}
