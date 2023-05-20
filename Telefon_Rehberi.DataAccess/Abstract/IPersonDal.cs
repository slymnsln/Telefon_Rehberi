using Telefon_Rehberi.Core.DataAccess;
using Telefon_Rehberi.Entities.Concrete;
using Telefon_Rehberi.Entities.DTOs;

namespace Telefon_Rehberi.DataAccess.Abstract
{
    public interface IPersonDal : IEntityRepository<Person>
    {
        IList<ReportByLocationDto> LocationReport();
    }
}
