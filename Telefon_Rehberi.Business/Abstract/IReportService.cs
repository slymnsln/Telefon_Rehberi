using Telefon_Rehberi.Core.Utilities.Results;
using Telefon_Rehberi.Entities.Concrete;

namespace Telefon_Rehberi.Business.Abstract
{
    public interface IReportService
    {
        Report Add(Report report);
        IResult Update(Report report);
        IDataResult<Report> GetById(int reportId);
        IDataResult<IList<Report>> GetAll();
    }
}
