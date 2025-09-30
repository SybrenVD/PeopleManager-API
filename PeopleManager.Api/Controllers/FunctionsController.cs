using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PeopleManager.Model;
using PeopleManager.Services;

namespace PeopleManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FunctionsController(FunctionService functionService) : ControllerBase
    {
        //Find
        [HttpGet]
        public async Task<IActionResult> Find()
        {
            var function = await functionService.Find();
            return Ok(function);
        }
        //Get
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var people = await functionService.Get(id);
            return Ok(people);
        }
        //Create
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Function function)
        {
            var newFunction = await functionService.Create(function);
            return Ok(newFunction);
        }
        //Update
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Function function)
        {
            var updatedFunction = await functionService.Update(id, function);
            return Ok(updatedFunction);
        }

        //Delete
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await functionService.Delete(id);
            return Ok();
        }
    }
}
