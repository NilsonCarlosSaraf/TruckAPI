namespace ProgrammingExercise.Domain.Entities;

public abstract class Vehicle
{
    public ChassisId ChassisId { get; set; }
    public string Color { get; set; }
    public abstract int NumberOfPassengers { get; }
    public abstract string Type { get; }
}

public class Car : Vehicle
{
    public override int NumberOfPassengers => 4;
    public override string Type => "Car";
}

public class Truck : Vehicle
{
    public override int NumberOfPassengers => 1;
    public override string Type => "Truck";
}

public class Bus : Vehicle
{
    public override int NumberOfPassengers => 42;
    public override string Type => "Bus";
}
