using ProgrammingExercise.Domain.Entities;

namespace ProgrammingExercise.Domain.Interfaces;

public interface IVehicleRepository
{
    void Add(Vehicle vehicle);
    Vehicle? GetByChassisId(ChassisId id);
    void UpdateColor(ChassisId id, string newColor);
    IEnumerable<Vehicle> GetAll();
}
