namespace ExceptionalWebApi.Exceptions;

public class UnauthorizedException : AppException
{
    public UnauthorizedException(object? error) : base(error)
    {
    }
}
