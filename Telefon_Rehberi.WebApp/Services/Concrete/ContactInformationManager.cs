using Newtonsoft.Json;
using System.Text;
using Telefon_Rehberi.WebApp.Models;
using Telefon_Rehberi.WebApp.Models.ServiceModel;
using Telefon_Rehberi.WebApp.Services.Abstact;

namespace Telefon_Rehberi.WebApp.Services.Concrete
{
    public class ContactInformationManager : IContactInformationService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        string apiUrl;

        public ContactInformationManager(IConfiguration configuration)
        {
            _configuration = configuration;
            var webServiceUrl = _configuration.GetSection("WebServiceURL").Get<string>();
            apiUrl = $"{webServiceUrl}/ContactInformations";

            _httpClient = HttpClientFactory.Create();
        }

        public ResponseModel Add(ContactInformationViewModel contactInformationViewModel)
        {
            var result = new ResponseModel { Success = false };

            HttpContent body = new StringContent(JsonConvert.SerializeObject(contactInformationViewModel), Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponseMessage = _httpClient.PostAsync($"{apiUrl}/Add", body).Result;
            if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonData = httpResponseMessage.Content.ReadAsStringAsync().Result;
                result = JsonConvert.DeserializeObject<ResponseModel>(jsonData);
            }
            return result;
        }

        public ResponseModel Delete(int contactInformationId)
        {
            var result = new ResponseModel { Success = false };

            HttpResponseMessage httpResponseMessage = _httpClient.DeleteAsync($"{apiUrl}/Delete?contactInformationId={contactInformationId}").Result;
            if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonData = httpResponseMessage.Content.ReadAsStringAsync().Result;
                result = JsonConvert.DeserializeObject<ResponseModel>(jsonData);
            }
            return result;
        }

        public ResponseDataModel<List<ContactInformation>> GetAllByPersonId(int personId)
        {
            var result = new ResponseDataModel<List<ContactInformation>>() { Success = false };
            HttpResponseMessage httpResponseMessage = _httpClient.GetAsync($"{apiUrl}/GetByPersonId?personId={personId}").Result;
            if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonData = httpResponseMessage.Content.ReadAsStringAsync().Result;
                result = JsonConvert.DeserializeObject<ResponseDataModel<List<ContactInformation>>>(jsonData);
            }
            return result;
        }
    }
}
