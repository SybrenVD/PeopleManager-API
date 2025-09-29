using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PeopleManager.Services;

namespace PeopleManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController(PersonService personService) : ControllerBase
    {

        //Find
        [HttpGet]
        public IActionResult Find()
        {
            var people = personService.Find();
            return Ok(people);
        }
        //Get
        [HttpGet("{id:int}")]
        public IActionResult Get([FromRoute] int id)
        {
            var people = personService.Get(id);
            return Ok(people);
        }
        //Create

        //Update

        //Delete

    }
}
