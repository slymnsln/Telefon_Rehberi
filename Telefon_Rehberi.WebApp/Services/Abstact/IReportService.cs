using Telefon_Rehberi.WebApp.Models.ServiceModel;

namespace Telefon_Rehberi.WebApp.Services.Abstact
{
    public interface IReportService
    {
        bool RequestReport();
        ResponseDataModel<List<Report>> GetAll();
        byte[] ReportDownload(int reportId);
    }
}
