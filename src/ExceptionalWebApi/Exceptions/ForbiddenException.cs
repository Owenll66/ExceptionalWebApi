using Microsoft.AspNetCore.Mvc;

namespace ExceptionalWebApi.Exceptions;

public class ForbiddenException : ApiException
{
    public override int? StatusCode { get; set; } = 403;

    public ForbiddenException(string? errorDetails = null)
    {
        ErrorResponse = new ProblemDetails()
        {
            Title = "Forbidden",
            Detail = errorDetails,
            Status = StatusCode
        };
    }

    public ForbiddenException(ProblemDetails problemDetails) : base(problemDetails)
    {
    }
}
