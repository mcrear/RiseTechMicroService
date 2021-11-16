using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RiseTech.Contact.Entities;
using RiseTech.Contact.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace RiseTech.Contact.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IPersonRepository _repository;
        private readonly ILogger<ContactController> _logger;

        public ContactController(IPersonRepository repository, ILogger<ContactController> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Person>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Person>>> GetPersons()
        {
            var persons = await _repository.GetPersons();
            return Ok(persons);
        }

        [HttpGet("{id:length(24)}", Name = "GetPerson")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Person), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Person>> GetPersonById(string id)
        {
            var person = await _repository.GetPerson(id);

            if (person == null)
            {
                _logger.LogError($"Person with id: {id}, not found.");
                return NotFound();
            }

            return Ok(person);
        }

        [Route("[action]/{firstName}", Name = "GetPersonByFirstName")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IEnumerable<Person>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Person>>> GetPersonByFirstName(string firstName)
        {
            var items = await _repository.GetPersonByFirstName(firstName);
            if (items == null)
            {
                _logger.LogError($"Persons with first name: {firstName} not found.");
                return NotFound();
            }
            return Ok(items);
        }

        [Route("[action]/{lastName}", Name = "GetPersonByLastName")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IEnumerable<Person>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Person>>> GetPersonByLastName(string lastName)
        {
            var items = await _repository.GetPersonByLastName(lastName);
            if (items == null)
            {
                _logger.LogError($"Persons with last name: {lastName} not found.");
                return NotFound();
            }
            return Ok(items);
        }

        [Route("[action]/{company}", Name = "GetPersonByCompany")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IEnumerable<Person>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Person>>> GetPersonByName(string company)
        {
            var items = await _repository.GetPersonByCompany(company);
            if (items == null)
            {
                _logger.LogError($"Persons with company: {company} not found.");
                return NotFound();
            }
            return Ok(items);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Person), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Person>> CreatePerson([FromBody] Person person)
        {
            await _repository.CreatePerson(person);

            return CreatedAtRoute("GetPerson", new { id = person.Id }, person);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Person), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdatePerson([FromBody] Person person)
        {
            return Ok(await _repository.UpdatePerson(person));
        }

        [HttpDelete("{id:length(24)}", Name = "DeletePerson")]
        [ProducesResponseType(typeof(Person), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeletePersonById(string id)
        {
            return Ok(await _repository.DeletePerson(id));
        }
    }
}
