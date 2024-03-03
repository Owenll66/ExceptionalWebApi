namespace ExceptionalWebApi.Exceptions;

public class ForbiddenException : AppException
{
    public ForbiddenException()
    {
    }

    public ForbiddenException(object error) : base(error)
    {
    }
}
