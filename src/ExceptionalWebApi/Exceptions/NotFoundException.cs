using ExceptionalWebApi.Responses;

namespace ExceptionalWebApi.Exceptions;

public class NotFoundException : ApiException
{
    public NotFoundException(object errorResponse, int? statusCode = null)
    {
        ErrorResponse = errorResponse;
        StatusCode = statusCode;
    }

    public NotFoundException(NotFoundProblemDetails? problemDetails = null)
    {
        ErrorResponse = problemDetails ?? new NotFoundProblemDetails();
        StatusCode = ((NotFoundProblemDetails)ErrorResponse).Status;
    }
}
