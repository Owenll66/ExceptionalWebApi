using ExceptionalWebApi.Responses;

namespace ExceptionalWebApi.Exceptions;

public class InternalServerErrorException : ApiException
{
    public InternalServerErrorException(InternalServerErrorProblemDetails? problemDetails = null)
    {
        ProblemDetails = problemDetails ?? new InternalServerErrorProblemDetails();
    }
}
