using ProgrammingExercise.Domain.Entities;
using ProgrammingExercise.Domain.Interfaces;

namespace ProgrammingExercise.Infrastructure.Repository;

public class InMemoryVehicleRepository : IVehicleRepository
{
    private readonly Dictionary<ChassisId, Vehicle> _vehicles = new();

    public void Add(Vehicle vehicle)
    {
        if (_vehicles.ContainsKey(vehicle.ChassisId))
            throw new InvalidOperationException("Vehicle with same chassis ID exists.");
        _vehicles[vehicle.ChassisId] = vehicle;
    }

    public Vehicle? GetByChassisId(ChassisId id) =>
        _vehicles.TryGetValue(id, out var vehicle) ? vehicle : null;

    public void UpdateColor(ChassisId id, string newColor)
    {
        if (_vehicles.TryGetValue(id, out var vehicle))
        {
            vehicle.Color = newColor;
        }
    }

    public IEnumerable<Vehicle> GetAll() => _vehicles.Values;
}
