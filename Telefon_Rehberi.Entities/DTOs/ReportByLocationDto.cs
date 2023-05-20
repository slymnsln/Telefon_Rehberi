using Telefon_Rehberi.Core.Entities;

namespace Telefon_Rehberi.Entities.DTOs
{
    public class ReportByLocationDto : IDto
    {
        public string Location { get; set; }
        public int PhoneCount { get; set; }
        public int PersonCount { get; set; }
    }
}
