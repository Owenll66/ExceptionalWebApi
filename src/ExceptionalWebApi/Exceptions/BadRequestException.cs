namespace ExceptionalWebApi.Exceptions;

public class BadRequestException : AppException
{
    public BadRequestException(object? error) : base(error)
    {
    }
}
