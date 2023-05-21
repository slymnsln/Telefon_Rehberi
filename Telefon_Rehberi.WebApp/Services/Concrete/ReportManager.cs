using Newtonsoft.Json;
using Telefon_Rehberi.WebApp.Models.ServiceModel;
using Telefon_Rehberi.WebApp.Services.Abstact;

namespace Telefon_Rehberi.WebApp.Services.Concrete
{
    public class ReportManager : IReportService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        string apiUrl;
        public ReportManager(IConfiguration configuration)
        {
            _configuration= configuration;
        }

        public ResponseDataModel<List<Report>> GetAll()
        {
            var result = new ResponseDataModel<List<Report>>() { Success = false };
            HttpResponseMessage httpResponseMessage = _httpClient.GetAsync($"{apiUrl}/GetAll").Result;
            if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonData = httpResponseMessage.Content.ReadAsStringAsync().Result;
                result = JsonConvert.DeserializeObject<ResponseDataModel<List<Report>>>(jsonData);
            }
            return result;
        }

        public byte[] ReportDownload(int reportId)
        {
            HttpResponseMessage httpResponseMessage = _httpClient.PostAsync($"{apiUrl}/ReportDownload?reportId={reportId}", null).Result;
            var file = httpResponseMessage.Content.ReadAsByteArrayAsync().Result;
            return file;
        }

        public bool RequestReport()
        {
            var result = new ResponseDataModel<List<Report>>() { Success = false };
            HttpResponseMessage httpResponseMessage = _httpClient.GetAsync($"{apiUrl}/RequestReport").Result;
            if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }
    }
}
