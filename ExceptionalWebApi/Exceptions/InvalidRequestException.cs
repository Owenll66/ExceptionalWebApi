namespace ExceptionalWebApi.Exceptions;

public class InvalidRequestException : AppException
{
    public InvalidRequestException(object exceptionObject) : base(exceptionObject)
    {
    }
}
