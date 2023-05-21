using Telefon_Rehberi.WebApp.Models.ServiceModel;
using Telefon_Rehberi.WebApp.Models;

namespace Telefon_Rehberi.WebApp.Services.Abstact
{
    public interface IContactInformationService
    {
        ResponseModel Add(ContactInformationViewModel contactInformationViewModel);
        ResponseDataModel<List<ContactInformation>> GetAllByPersonId(int personId);
        ResponseModel Delete(int contactInformationId);
    }
}
