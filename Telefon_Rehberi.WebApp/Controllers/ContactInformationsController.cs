using Microsoft.AspNetCore.Mvc;
using Telefon_Rehberi.WebApp.Models;
using Telefon_Rehberi.WebApp.Services.Abstact;

namespace Telefon_Rehberi.WebApp.Controllers
{
    public class ContactInformationsController : Controller
    {
        private readonly IContactInformationService _contactInformationService;
        public ContactInformationsController(IContactInformationService contactInformationService)
        {
            _contactInformationService = contactInformationService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List(int id)
        {
            var result = _contactInformationService.GetAllByPersonId(id);
            return View(result.Data);
        }

        [HttpGet]
        public IActionResult Create(int id)
        {
            var contactInformationViewModel = new ContactInformationViewModel { PersonUUID = id };
            return View(contactInformationViewModel);
        }

        [HttpPost]
        public IActionResult Create(ContactInformationViewModel contactInformationViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = _contactInformationService.Add(contactInformationViewModel);
                if (result.Success)
                    return Redirect($"/ContactInformations/List/{contactInformationViewModel.PersonUUID}");
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var result = _contactInformationService.Delete(id);
                if (result.Success)
                    return Redirect("/Persons/Index");
            }
            return View();
        }
    }
}
