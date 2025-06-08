using ProgrammingExercise.Domain.Entities;

namespace ProgrammingExercise.Application.Services;

public interface IVehicleService
{
    void AddVehicle(Vehicle vehicle);
    void UpdateColor(ChassisId id, string newColor);
    Vehicle? GetByChassisId(ChassisId id);
    IEnumerable<Vehicle> GetAll();
}
