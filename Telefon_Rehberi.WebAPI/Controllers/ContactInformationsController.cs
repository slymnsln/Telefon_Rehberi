using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Telefon_Rehberi.Business.Abstract;
using Telefon_Rehberi.Entities.Concrete;

namespace Telefon_Rehberi.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactInformationsController : ControllerBase
    {
        private readonly IContactInformationService _contactInformationService;
        public ContactInformationsController(IContactInformationService contactInformationService)
        {
            _contactInformationService = contactInformationService;
        }

        [HttpGet("GetByPersonId")]
        public IActionResult GetByPersonId(int personId)
        {
            var result = _contactInformationService.GetListByPersonId(personId);

            return Ok(result);
        }

        [HttpPost("Add")]
        public IActionResult Add(ContactInformation contactInformation)
        {
            var result = _contactInformationService.Add(contactInformation);

            return Ok(result);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int contactInformationId)
        {
            var result = _contactInformationService.Delete(contactInformationId);

            return Ok(result);
        }
    }
}
