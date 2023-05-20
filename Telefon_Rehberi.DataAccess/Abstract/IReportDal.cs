using Telefon_Rehberi.Core.DataAccess;
using Telefon_Rehberi.Entities.Concrete;

namespace Telefon_Rehberi.DataAccess.Abstract
{
    public interface IReportDal : IEntityRepository<Report>
    {
        Report CustomAdd(Report report);
    }
}
