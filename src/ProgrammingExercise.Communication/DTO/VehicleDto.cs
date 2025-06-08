using ProgrammingExercise.Domain.Entities;

namespace ProgrammingExercise.Communication.DTO;

public class VehicleDto
{
    public string Series { get; set; }
    public uint Number { get; set; }
    public string Type { get; set; }
    public string Color { get; set; }

    public Vehicle ToDomain()
    {
        var chassisId = new ChassisId { Series = Series, Number = Number };
        return Type.ToLower() switch
        {
            "car" => new Car { ChassisId = chassisId, Color = Color },
            "truck" => new Truck { ChassisId = chassisId, Color = Color },
            "bus" => new Bus { ChassisId = chassisId, Color = Color },
            _ => throw new ArgumentException("Invalid vehicle type")
        };
    }
}
