using DemoApplication.Models;
using DemoApplication.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DemoApplication.Controllers;

[Route("api/people")]
[ApiController]
public class PeopleController : ControllerBase
{
    private readonly IPersonRepository _personRepository;

    public PeopleController(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> AddPerson([FromBody] Person person)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _personRepository.AddPersonAsync(person);
            return StatusCode(StatusCodes.Status201Created, "Person added successfully.");
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Server error.");
        }
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetPersons()
    {
        try
        {
            var persons = await _personRepository.GetPeopleAsync();

            return Ok(persons);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
        }
    }
}