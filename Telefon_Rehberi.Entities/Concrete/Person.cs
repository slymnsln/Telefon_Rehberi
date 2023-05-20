using System.ComponentModel.DataAnnotations;

namespace Telefon_Rehberi.Entities.Concrete
{
    public class Person
    {
        [Key]
        public int UUID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
    }
}
