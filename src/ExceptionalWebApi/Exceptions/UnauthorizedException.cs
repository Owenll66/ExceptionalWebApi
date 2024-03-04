using ExceptionalWebApi.Responses;

namespace ExceptionalWebApi.Exceptions;

public class UnauthorizedException : ApiException
{
    public UnauthorizedException(UnauthorizedProblemDetails? problemDetails = null)
    {
        ProblemDetails = problemDetails ?? new UnauthorizedProblemDetails();
    }
}
