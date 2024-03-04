using ExceptionalWebApi.Responses;

namespace ExceptionalWebApi.Exceptions;

public class NotFoundException : ApiException
{
    public NotFoundException(NotFoundProblemDetails? problemDetails = null)
    {
        ProblemDetails = problemDetails ?? new NotFoundProblemDetails();
    }
}
