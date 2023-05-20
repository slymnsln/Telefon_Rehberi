using Microsoft.EntityFrameworkCore;
using Telefon_Rehberi.Core.DataAccess.EntityFramework;
using Telefon_Rehberi.DataAccess.Abstract;
using Telefon_Rehberi.DataAccess.Concrete.Context;
using Telefon_Rehberi.Entities.Concrete;

namespace Telefon_Rehberi.DataAccess.Concrete
{
    public class EfReportDal : EfEntityRepositoryBase<Report, PgAdminContext>, IReportDal
    {
        public Report CustomAdd(Report report)
        {
            using (var context = new PgAdminContext())
            {
                var addedEntity = context.Entry(report);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
                return addedEntity.Entity;
            }
        }
    }
}
