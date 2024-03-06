using ExceptionalWebApi.Responses;

namespace ExceptionalWebApi.Exceptions;

public class UnauthorizedException : ApiException
{
    public UnauthorizedException(object errorResponse, int? statusCode = null)
    {
        ErrorResponse = errorResponse;
        StatusCode = statusCode;
    }

    public UnauthorizedException(UnauthorizedProblemDetails? problemDetails = null)
    {
        ErrorResponse = problemDetails ?? new UnauthorizedProblemDetails();
        StatusCode = ((UnauthorizedProblemDetails)ErrorResponse).Status;
    }
}
