using Microsoft.AspNetCore.Mvc;
using ProgrammingExercise.Application.Services;
using ProgrammingExercise.Communication.DTO;
using ProgrammingExercise.Domain.Entities;
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

    [HttpPut("{series}/{number}/color")]
    public IActionResult UpdateColor(string series, uint number, [FromBody] UpdateColorDto dto)
    {

        var chassisId = new ChassisId { Series = series, Number = number };
        _service.UpdateColor(chassisId, dto.Color);
        return NoContent();
    }

    [HttpGet("{series}/{number}")]
    public IActionResult GetVehicle(string series, uint number)
    {

        var vehicle = _service.GetByChassisId(new ChassisId { Series = series, Number = number });
        return vehicle == null ? NotFound() : Ok(vehicle);
    }

    [HttpGet]
    public IActionResult GetAll() => Ok(_service.GetAll());

}
