namespace ProgrammingExercise.ExceptionsBase;

public class VehicleAlreadyExistsException : Exception
{
    public VehicleAlreadyExistsException() : base("Vehicle with the same chassis ID already exists.") { }
}
