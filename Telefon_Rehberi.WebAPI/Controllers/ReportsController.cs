using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Telefon_Rehberi.Business.Abstract;

namespace Telefon_Rehberi.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IRabbitMQService _rabbitMqService;
        private readonly IReportService _reportService;
        public ReportsController(IRabbitMQService rabbitMqService, IReportService reportService)
        {
            _rabbitMqService = rabbitMqService;
            _reportService = reportService;
        }

        [HttpGet("RequestReport")]
        public IActionResult RequestReport()
        {
            _rabbitMqService.RequestReport();

            return Ok();
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var report = _reportService.GetAll();

            return Ok(report);
        }

        [HttpPost("ReportDownload")]
        public IActionResult ReportDownload(int reportId)
        {

            var report = _reportService.GetById(reportId);
            var fileName = System.IO.Path.GetFileName(report.Data.ReportPath);
            var content = System.IO.File.ReadAllBytes(report.Data.ReportPath);
            new FileExtensionContentTypeProvider()
                .TryGetContentType(fileName, out string contentType);

            return File(content, contentType, fileName);
        }
    }
}
