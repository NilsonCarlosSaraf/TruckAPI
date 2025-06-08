using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProgrammingExercise.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class VehiclesController : ControllerBase
{
    [HttpPost]
    public IActionResult AddVehicle()
    {
        return Created();
    }

    [HttpPut()]
    public IActionResult UpdateColor()
    {
        
        return NoContent();
    }

    [HttpGet]
    public IActionResult GetAll() => Ok();

    [HttpGet("{series}/{number}")]
    public IActionResult GetVehicle()
    {
       
        return Ok();
    }

}
