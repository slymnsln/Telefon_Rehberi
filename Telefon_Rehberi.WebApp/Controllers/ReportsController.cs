using Microsoft.AspNetCore.Mvc;
using Telefon_Rehberi.WebApp.Services.Abstact;

namespace Telefon_Rehberi.WebApp.Controllers
{
    public class ReportsController : Controller
    {
        private readonly IReportService _reportService;
        public ReportsController(IReportService reportService)
        {
            _reportService = reportService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            var result = _reportService.GetAll();
            return View(result.Data);
        }

        public IActionResult ReportDownload(int id)
        {
            if (ModelState.IsValid)
            {
                var result = _reportService.ReportDownload(id);
                return File(result, "application/xlsx", $"Konum_Raporu_{DateTime.Now.Ticks}.xlsx");
            }
            return View();
        }

        public IActionResult RequestReport()
        {
            if (ModelState.IsValid)
            {
                var result = _reportService.RequestReport();
                if (result)
                    return RedirectToAction("List");
            }
            return View();
        }
    }
}
