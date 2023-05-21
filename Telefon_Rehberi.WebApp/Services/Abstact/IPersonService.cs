using Telefon_Rehberi.WebApp.Models.ServiceModel;
using Telefon_Rehberi.WebApp.Models;

namespace Telefon_Rehberi.WebApp.Services.Abstact
{
    public interface IPersonService
    {
        ResponseModel Add(PersonViewModel personViewModel);
        ResponseDataModel<List<Person>> GetAll();
        ResponseModel Delete(int personId);
    }
}
