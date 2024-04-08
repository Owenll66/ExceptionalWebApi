using Microsoft.AspNetCore.Mvc;

namespace ExceptionalWebApi.Exceptions;

public class NotFoundException : ApiException
{
    public override int? StatusCode { get; set; } = 404;

    public NotFoundException(string? errorDetails = null)
    {
        ErrorResponse = new ProblemDetails()
        {
            Title = "Not Found",
            Detail = errorDetails,
            Status = StatusCode
        };
    }

    public NotFoundException(ProblemDetails problemDetails) : base(problemDetails)
    {
    }
}
