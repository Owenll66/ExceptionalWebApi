namespace ExceptionalWebApi.Exceptions;

public class ForbiddenException : AppException
{
    public ForbiddenException(object? error) : base(error)
    {
    }
}
