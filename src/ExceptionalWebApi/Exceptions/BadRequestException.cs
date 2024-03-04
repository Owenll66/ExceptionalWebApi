using ExceptionalWebApi.Responses;

namespace ExceptionalWebApi.Exceptions;

public class BadRequestException : ApiException
{
    public BadRequestException(BadRequestProblemDetails? problemDetails = null)
    {
        ProblemDetails = problemDetails ?? new BadRequestProblemDetails();
    }
}