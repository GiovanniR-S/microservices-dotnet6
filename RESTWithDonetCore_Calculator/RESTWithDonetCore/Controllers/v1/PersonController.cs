using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RESTWithDonetCore_Calculator.Model;
using RESTWithDonetCore_Calculator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace RESTWithDonetCore.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController:ControllerBase {
        private readonly ILogger<PersonController> _logger;
        private IPersonService personService;
        public PersonController (ILogger<PersonController> logger, IPersonService personService) {
            _logger = logger;
            this.personService = personService;
        }
        [HttpGet]
        public IActionResult GetFindAll () {
            
            return Ok(personService.FindAll());
        }
        
        [HttpGet("{id}")]
        public IActionResult GetById (long id) {
            var person = personService.FindById(id);
            if(person == null) {
                return NotFound();
            }
            return Ok(person);
        }
        [HttpPost]
        public IActionResult CreatePerson ([FromBody] Person person) {
            if(person == null) {
                return BadRequest();
            }
            return Ok(personService.Create(person));
        }
        [HttpPut]
        public IActionResult UpdatePerson ([FromBody] Person person) {
            if(person == null) {
                return BadRequest();
            }
            return Ok(personService.Update(person));
        }
        [HttpDelete("{id}")]
        public IActionResult DeletePerson (long id) {
            personService.Delete(id);
            return NoContent();
        }
    }
}
