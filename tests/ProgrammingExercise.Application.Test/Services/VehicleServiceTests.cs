using Bogus;
using FluentAssertions;
using ProgrammingExercise.Application.Services;
using ProgrammingExercise.Domain.Entities;
using ProgrammingExercise.Domain.Interfaces;
using ProgrammingExercise.ExceptionsBase;
using ProgrammingExercise.Infrastructure.Repository;

namespace ProgrammingExercise.Application.Test.Services
{
    public class VehicleServiceTests
    {
        private readonly IVehicleService _service;
        private readonly Faker _faker;

        public VehicleServiceTests()
        {
            IVehicleRepository repo = new InMemoryVehicleRepository();
            _service = new VehicleService(repo);
            _faker = new Faker();
        }

        [Fact]
        public void AddVehicle_ShouldSucceed_WhenChassisIdIsUnique()
        {
            var vehicle = new Car
            {
                ChassisId = new ChassisId
                {
                    Series = _faker.Random.AlphaNumeric(5),
                    Number = _faker.Random.UInt()
                },
                Color = _faker.Commerce.Color()
            };

            _service.AddVehicle(vehicle);

            var result = _service.GetByChassisId(vehicle.ChassisId);
            result.Should().NotBeNull();
            result!.Type.Should().Be("Car");
            result.Color.Should().Be(vehicle.Color);
        }

        [Fact]
        public void AddVehicle_ShouldThrow_WhenChassisIdAlreadyExists()
        {
            var chassisId = new ChassisId { Series = "XTEST", Number = 999 };
            var car1 = new Car { ChassisId = chassisId, Color = "Red" };
            var car2 = new Car { ChassisId = chassisId, Color = "Blue" };

            _service.AddVehicle(car1);

            Action act = () => _service.AddVehicle(car2);

            act.Should().Throw<VehicleAlreadyExistsException>()
               .WithMessage("Vehicle with the same chassis ID already exists.");
        }

        [Fact]
        public void UpdateColor_ShouldChangeColor_WhenVehicleExists()
        {
            var chassisId = new ChassisId { Series = "CHANGE", Number = 1234 };
            var car = new Car { ChassisId = chassisId, Color = "Gray" };

            _service.AddVehicle(car);
            _service.UpdateColor(chassisId, "Yellow");

            var updated = _service.GetByChassisId(chassisId);
            updated!.Color.Should().Be("Yellow");
        }

        [Fact]
        public void GetAll_ShouldReturnAllAddedVehicles()
        {
            var car = new Car
            {
                ChassisId = new ChassisId { Series = "A", Number = 1 },
                Color = "White"
            };
            var truck = new Truck
            {
                ChassisId = new ChassisId { Series = "B", Number = 2 },
                Color = "Black"
            };

            _service.AddVehicle(car);
            _service.AddVehicle(truck);

            var result = _service.GetAll();

            result.Should().HaveCount(2);
            result.Should().Contain(v => v.Type == "Car" && v.Color == "White");
            result.Should().Contain(v => v.Type == "Truck" && v.Color == "Black");
        }
    }
}
