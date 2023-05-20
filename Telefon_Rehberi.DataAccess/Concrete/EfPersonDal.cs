using Telefon_Rehberi.Core.DataAccess.EntityFramework;
using Telefon_Rehberi.DataAccess.Abstract;
using Telefon_Rehberi.DataAccess.Concrete.Context;
using Telefon_Rehberi.Entities.Concrete;
using Telefon_Rehberi.Entities.DTOs;

namespace Telefon_Rehberi.DataAccess.Concrete
{
    public class EfPersonDal : EfEntityRepositoryBase<Person, PgAdminContext>, IPersonDal
    {
        public IList<ReportByLocationDto> LocationReport()
        {
            using (var context = new PgAdminContext())
            {
                var result = from cin in context.ContactInformations
                             join p in context.Persons on cin.PersonUUID equals p.UUID
                             group cin by new { cin.Location } into Group
                             select new ReportByLocationDto
                             {
                                 Location = Group.FirstOrDefault().Location,
                                 PhoneCount = Group.Count(),
                                 PersonCount = Group.GroupBy(x => x.PersonUUID).Count()
                             };
                return result.ToList();
            }
        }
    }
}
