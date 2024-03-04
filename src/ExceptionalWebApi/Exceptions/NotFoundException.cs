namespace ExceptionalWebApi.Exceptions;

public class NotFoundException : AppException
{
    public NotFoundException(object? error) : base(error)
    {
    }
}
