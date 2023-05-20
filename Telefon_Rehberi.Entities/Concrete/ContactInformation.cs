using System.ComponentModel.DataAnnotations;

namespace Telefon_Rehberi.Entities.Concrete
{
    public class ContactInformation
    {
        [Key]
        public int Id { get; set; }
        public int PersonUUID { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
    }
}
