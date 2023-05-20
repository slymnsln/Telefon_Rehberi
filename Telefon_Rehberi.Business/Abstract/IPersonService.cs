using Telefon_Rehberi.Core.Utilities.Results;
using Telefon_Rehberi.Entities.Concrete;
using Telefon_Rehberi.Entities.DTOs;

namespace Telefon_Rehberi.Business.Abstract
{
    public interface IPersonService
    {
        IResult Add(Person person);
        IResult Delete(int personId);
        IDataResult<IList<Person>> GetAll();
        IList<ReportByLocationDto> GetLocationAllReports();
    }
}
