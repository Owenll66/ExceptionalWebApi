namespace ExceptionalWebApi.Exceptions;

public class InvalidRequestException : AppException
{
    public InvalidRequestException()
    {
    }

    public InvalidRequestException(object error) : base(error)
    {
    }
}
