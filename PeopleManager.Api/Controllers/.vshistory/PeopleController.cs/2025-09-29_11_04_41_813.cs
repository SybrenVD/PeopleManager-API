using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PeopleManager.Model;
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
        [HttpPost]
        public IActionResult Create(Person person)
        {
            var newPerson = personService.Create(person);
            return Ok(newPerson);
        }
        //Update
        [HttpPost("{id:int}")]
        public IActionResult Update([FromRoute] int id, Person person)
        {
            var updatedPerson = personService.Update(id, person);
            return Ok(updatedPerson);
        }

        //Delete
        [HttpDelete]
        public IActionResult Delete([FromRoute] int id)
        {
            personService.Delete(id);
            return Ok();
        }
    }
}
