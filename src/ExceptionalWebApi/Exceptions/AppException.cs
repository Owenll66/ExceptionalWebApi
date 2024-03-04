namespace ExceptionalWebApi.Exceptions;

public class AppException : Exception
{
    public object? ExceptionObject { get; set; }

    public AppException() { }

    public AppException(object? exceptionObject)
    {
        ExceptionObject = exceptionObject;
    }
}