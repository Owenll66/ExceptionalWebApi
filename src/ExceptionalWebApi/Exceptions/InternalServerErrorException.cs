using ExceptionalWebApi.Responses;

namespace ExceptionalWebApi.Exceptions;

public class InternalServerErrorException : ApiException
{
    public InternalServerErrorException(object errorResponse, int? statusCode = null)
    {
        ErrorResponse = errorResponse;
        StatusCode = statusCode;
    }

    public InternalServerErrorException(InternalServerErrorProblemDetails? problemDetails = null)
    {
        ErrorResponse = problemDetails ?? new InternalServerErrorProblemDetails();
        StatusCode = ((InternalServerErrorProblemDetails)ErrorResponse).Status;
    }
}
