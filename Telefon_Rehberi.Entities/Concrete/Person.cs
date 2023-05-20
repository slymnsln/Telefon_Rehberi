using System.ComponentModel.DataAnnotations;
using Telefon_Rehberi.Core.Entities;

namespace Telefon_Rehberi.Entities.Concrete
{
    public class Person : IEntity
    {
        [Key]
        public int UUID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
    }
}
