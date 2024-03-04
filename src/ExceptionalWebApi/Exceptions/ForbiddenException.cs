using ExceptionalWebApi.Responses;

namespace ExceptionalWebApi.Exceptions;

public class ForbiddenException : ApiException
{
    public ForbiddenException(ForbiddenProblemDetails? problemDetails = null)
    {
        ProblemDetails = problemDetails ?? new ForbiddenProblemDetails();
    }
}
