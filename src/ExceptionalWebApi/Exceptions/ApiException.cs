using Microsoft.AspNetCore.Mvc;

namespace ExceptionalWebApi.Exceptions;

public abstract class ApiException : Exception
{
    public object ErrorResponse { get; set; }

    public abstract int? StatusCode { get; set; }
    public abstract string? Title { get; set; }

    public ApiException()
    {
        ErrorResponse = new();
    }

    public ApiException(ValidationProblemDetails validationProblemDetails)
    {
        ErrorResponse = validationProblemDetails;
    }

    public ApiException(ProblemDetails problemDetails)
    {
        ErrorResponse = problemDetails;
    }
}