namespace ProgrammingExercise.Domain.Entities;

public class ChassisId
{
    public string Series { get; set; }
    public uint Number { get; set; }

    public override bool Equals(object? obj) =>
        obj is ChassisId other && Series == other.Series && Number == other.Number;

    public override int GetHashCode() => HashCode.Combine(Series, Number);
}
