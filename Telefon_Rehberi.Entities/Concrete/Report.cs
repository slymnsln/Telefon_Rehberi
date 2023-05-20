using System.ComponentModel.DataAnnotations;

namespace Telefon_Rehberi.Entities.Concrete
{
    public class Report
    {
        [Key]
        public int UUID { get; set; }
        public DateTime ReportCreateDate { get; set; }
        public string ReportStatus { get; set; }
        public string ReportPath { get; set; }
    }
}
