using Microsoft.AspNetCore.Mvc;
using ProgrammingExercise.Application.Services;
using ProgrammingExercise.Communication.DTO;
using ProgrammingExercise.ExceptionsBase;

namespace ProgrammingExercise.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class VehiclesController : ControllerBase
{
    private readonly IVehicleService _service;

    public VehiclesController(IVehicleService service)
    {
        _service = service;
    }
 
    [HttpPost]
    public IActionResult AddVehicle([FromBody] VehicleDto dto)
    {
        try
        {
            var vehicle = dto.ToDomain();
            _service.AddVehicle(vehicle);
            return CreatedAtAction(nameof(GetVehicle), new { series = dto.Series, number = dto.Number }, vehicle);
        }
        catch (VehicleAlreadyExistsException ex)
        {
            return Conflict(ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
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
