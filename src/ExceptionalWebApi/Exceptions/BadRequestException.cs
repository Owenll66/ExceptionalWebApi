using ExceptionalWebApi.Responses;

namespace ExceptionalWebApi.Exceptions;

public class BadRequestException : ApiException
{
    public BadRequestException(object errorResponse, int? statusCode = null)
    {
        ErrorResponse = errorResponse;
        StatusCode = statusCode;
    }

    public BadRequestException(BadRequestProblemDetails? errorResponse = null)
    {
        ErrorResponse = errorResponse ?? new BadRequestProblemDetails();
        StatusCode = ((BadRequestProblemDetails)ErrorResponse).Status;
    }
}