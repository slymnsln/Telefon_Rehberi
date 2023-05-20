using System.ComponentModel.DataAnnotations;
using Telefon_Rehberi.Core.Entities;

namespace Telefon_Rehberi.Entities.Concrete
{
    public class ContactInformation : IEntity
    {
        [Key]
        public int Id { get; set; }
        public int PersonUUID { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
    }
}
