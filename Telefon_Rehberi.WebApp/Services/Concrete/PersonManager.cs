using Newtonsoft.Json;
using System.Text;
using Telefon_Rehberi.WebApp.Models;
using Telefon_Rehberi.WebApp.Models.ServiceModel;
using Telefon_Rehberi.WebApp.Services.Abstact;

namespace Telefon_Rehberi.WebApp.Services.Concrete
{
    public class PersonManager: IPersonService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        string apiUrl;
        public PersonManager(IConfiguration configuration)
        {
            _configuration= configuration;
        }

        public ResponseModel Add(PersonViewModel personViewModel)
        {
            var result = new ResponseModel { Success = false };

            HttpContent body = new StringContent(JsonConvert.SerializeObject(personViewModel), Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponseMessage = _httpClient.PostAsync($"{apiUrl}/Add", body).Result;
            if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonData = httpResponseMessage.Content.ReadAsStringAsync().Result;
                result = JsonConvert.DeserializeObject<ResponseModel>(jsonData);
            }
            return result;
        }

        public ResponseModel Delete(int personId)
        {
            var result = new ResponseModel { Success = false };

            HttpResponseMessage httpResponseMessage = _httpClient.DeleteAsync($"{apiUrl}/Delete?personId={personId}").Result;
            if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonData = httpResponseMessage.Content.ReadAsStringAsync().Result;
                result = JsonConvert.DeserializeObject<ResponseModel>(jsonData);
            }
            return result;
        }

        public ResponseDataModel<List<Person>> GetAll()
        {
            var result = new ResponseDataModel<List<Person>>() { Success = false };
            HttpResponseMessage httpResponseMessage = _httpClient.GetAsync($"{apiUrl}/GetAll").Result;
            if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonData = httpResponseMessage.Content.ReadAsStringAsync().Result;
                result = JsonConvert.DeserializeObject<ResponseDataModel<List<Person>>>(jsonData);
            }
            return result;
        }
    }
}
