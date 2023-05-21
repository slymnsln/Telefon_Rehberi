using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Telefon_Rehberi.Entities.Concrete;

namespace Telefon_Rehberi.DataAccess.Concrete.Context
{
    public class PgAdminContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            JToken jAppSettings = JToken.Parse(File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "../Telefon_Rehberi.WebAPI/appsettings.json")));

            string _pgAdminContext = jAppSettings["ConnectionStrings"]["PgAdminContext"].ToString();

            optionsBuilder.UseNpgsql(_pgAdminContext);

        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<ContactInformation> ContactInformations { get; set; }
        public DbSet<Report> Reports { get; set; }
    }
}
