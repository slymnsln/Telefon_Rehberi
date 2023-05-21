using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Telefon_Rehberi.Business.Abstract;
using Telefon_Rehberi.Entities.Concrete;

namespace Telefon_Rehberi.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonService _personService;
        public PersonsController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _personService.GetAll();

            return Ok(result);
        }

        [HttpPost("Add")]
        public IActionResult Add(Person person)
        {
            var result = _personService.Add(person);

            return Ok(result);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int personId)
        {
            var result = _personService.Delete(personId);

            return Ok(result);
        }
    }
}
