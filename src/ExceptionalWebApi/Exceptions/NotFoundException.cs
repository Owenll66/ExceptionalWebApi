using Microsoft.AspNetCore.Mvc;

namespace ExceptionalWebApi.Exceptions;

public class NotFoundException : ApiException
{
    public override int? StatusCode { get; set; } = 404;
    public override string? Title { get; set; } = "Not Found";

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
        problemDetails.Title ??= Title;
        problemDetails.Status ??= StatusCode;
    }
}
