namespace Telefon_Rehberi.WebApp.Models.ServiceModel
{
    public class Report
    {
        public int UUID { get; set; }
        public DateTime ReportCreateDate { get; set; }
        public string ReportStatus { get; set; }
        public string ReportPath { get; set; }
    }
}
