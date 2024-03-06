namespace ExceptionalWebApi.Exceptions;

public class ApiException : Exception
{
    public object ErrorResponse { get; set; }

    public int? StatusCode { get; set; }

    public ApiException()
    {
        ErrorResponse = new();
    }

    public ApiException(object errorResponse)
    {
        ErrorResponse = errorResponse;
    }
}