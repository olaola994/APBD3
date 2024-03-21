namespace Kontenery.Exeptions;

public class OverfillException : Exception
{
    public OverfillException()
    {
        Console.WriteLine("Overfill Exception");
    }
    public OverfillException(string? message) : base(message)
    {
    }

    public OverfillException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}