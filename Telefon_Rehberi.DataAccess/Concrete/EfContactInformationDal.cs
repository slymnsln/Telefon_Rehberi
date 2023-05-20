using Telefon_Rehberi.Core.DataAccess.EntityFramework;
using Telefon_Rehberi.DataAccess.Abstract;
using Telefon_Rehberi.DataAccess.Concrete.Context;
using Telefon_Rehberi.Entities.Concrete;

namespace Telefon_Rehberi.DataAccess.Concrete
{
    public class EfContactInformationDal : EfEntityRepositoryBase<ContactInformation, PgAdminContext>, IContactInformationDal
    {
    }
}
