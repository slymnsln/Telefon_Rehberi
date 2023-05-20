using System.ComponentModel.DataAnnotations;
using Telefon_Rehberi.Core.Entities;

namespace Telefon_Rehberi.Entities.Concrete
{
    public class Report : IEntity
    {
        [Key]
        public int UUID { get; set; }
        public DateTime ReportCreateDate { get; set; }
        public string ReportStatus { get; set; }
        public string ReportPath { get; set; }
    }
}
