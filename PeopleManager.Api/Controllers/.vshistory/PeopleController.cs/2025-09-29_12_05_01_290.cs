using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
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
        public async Task<IActionResult> Find()
        {
            var people = await personService.Find();
            return Ok(people);
        }
        //Get
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var people = await personService.Get(id);
            return Ok(people);
        }
        //Create
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Person person)
        {
            var newPerson = await personService.Create(person);
            return Ok(newPerson);
        }
        //Update
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Person person)
        {
            var updatedPerson = await personService.Update(id, person);
            return Ok(updatedPerson);
        }

        //Delete
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await personService.Delete(id);
            return Ok();
        }
    }
}
