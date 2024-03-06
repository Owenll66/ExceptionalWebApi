using ExceptionalWebApi.Responses;

namespace ExceptionalWebApi.Exceptions;

public class ForbiddenException : ApiException
{
    public ForbiddenException(object errorResponse, int? statusCode = null)
    {
        ErrorResponse = errorResponse;
        StatusCode = statusCode;
    }

    public ForbiddenException(ForbiddenProblemDetails? problemDetails = null)
    {
        ErrorResponse = problemDetails ?? new ForbiddenProblemDetails();
        StatusCode = ((ForbiddenProblemDetails)ErrorResponse).Status;
    }
}
