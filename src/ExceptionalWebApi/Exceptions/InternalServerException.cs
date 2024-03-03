namespace ExceptionalWebApi.Exceptions;

public class InternalServerException : AppException
{
    public InternalServerException()
    {
    }

    public InternalServerException(object error) : base(error)
    {
    }
}
