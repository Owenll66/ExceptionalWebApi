namespace ExceptionalWebApi.Exceptions;

public class InternalServerException : AppException
{
    public InternalServerException(object? error) : base(error)
    {
    }
}
