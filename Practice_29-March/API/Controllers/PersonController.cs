using API.Model;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

       
        [HttpGet]
        public async Task<ActionResult<List<Person>>> GetAll()
        {
            var list = await _personService.GetAll();
            return Ok(list);
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetById(int id)
        {
            var person = await _personService.GetById(id);

            if (person == null)
                return NotFound("Person not found");

            return Ok(person);
        }

        
        [HttpPost]
        public async Task<ActionResult<Person>> Add(Person person)
        {
            var created = await _personService.Add(person);
            return Ok(created);
        }

        
        [HttpPut]
        public async Task<ActionResult<Person>> Update(Person person)
        {
            var updated = await _personService.Update(person);

            if (updated == null)
                return NotFound("Person not found");

            return Ok(updated);
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _personService.Delete(id);

            if (!result)
                return NotFound("Person not found");

            return Ok("Person successfully deleted");
        }
    }
}