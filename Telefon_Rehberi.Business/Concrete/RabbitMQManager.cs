using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;
using Telefon_Rehberi.Business.Abstract;
using Telefon_Rehberi.Entities.Concrete;

namespace Telefon_Rehberi.Business.Concrete
{
    public class RabbitMQManager : IRabbitMQService
    {
        private readonly IReportService _reportService;
        private readonly IPersonService _personService;
        IConnection connection;
        IModel channel;
        public RabbitMQManager(IReportService reportService, IPersonService personService, IConfiguration configuration)
        {
            _reportService = reportService;
            _personService = personService;

            var factory = new ConnectionFactory();
            factory.Uri = new Uri(configuration.GetSection("RabbitMQService").Value);
            connection = factory.CreateConnection();
            channel = connection.CreateModel();
            channel.QueueDeclare("Reports", true, false, false);
        }

        public void RequestReport()
        {
            var report = CreateReport();

            var reportData = _personService.GetLocationAllReports();
            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(reportData));

            IBasicProperties messageProperties = channel.CreateBasicProperties();
            messageProperties.MessageId = report.UUID.ToString();
            channel.BasicPublish(String.Empty, "Reports", messageProperties, body);
        }

        private Report CreateReport()
        {
            var report = new Report
            {
                ReportCreateDate = DateTime.UtcNow,
                ReportPath = "",
                ReportStatus = "Hazırlanıyor"
            };
            return _reportService.Add(report);
        }
    }
}
