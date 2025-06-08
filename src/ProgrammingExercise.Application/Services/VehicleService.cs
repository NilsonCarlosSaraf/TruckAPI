using ProgrammingExercise.Domain.Entities;
using ProgrammingExercise.Domain.Interfaces;
using ProgrammingExercise.ExceptionsBase;

namespace ProgrammingExercise.Application.Services;

public class VehicleService : IVehicleService
{
    private readonly IVehicleRepository _repository;

    public VehicleService(IVehicleRepository repository)
    {
        _repository = repository;
    }

    public void AddVehicle(Vehicle vehicle)
    {
        if (_repository.GetByChassisId(vehicle.ChassisId) != null)
            throw new VehicleAlreadyExistsException();

        _repository.Add(vehicle);
    }

    public void UpdateColor(ChassisId id, string newColor) =>
        _repository.UpdateColor(id, newColor);

    public Vehicle? GetByChassisId(ChassisId id) =>
        _repository.GetByChassisId(id);

    public IEnumerable<Vehicle> GetAll() => _repository.GetAll();
}
