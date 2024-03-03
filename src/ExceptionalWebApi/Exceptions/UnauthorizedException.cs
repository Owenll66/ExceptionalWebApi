namespace ExceptionalWebApi.Exceptions;

public class UnauthorizedException : AppException
{
    public UnauthorizedException()
    {
    }

    public UnauthorizedException(object error) : base(error)
    {
    }
}
