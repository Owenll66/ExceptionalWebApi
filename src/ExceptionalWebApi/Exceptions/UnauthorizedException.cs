using Microsoft.AspNetCore.Mvc;

namespace ExceptionalWebApi.Exceptions;

public class UnauthorizedException : ApiException
{
    public override int? StatusCode { get; set; } = 401;
    public override string? Title { get; set; } = "Unauthorized";

    public UnauthorizedException(string? errorDetails = null)
    {
        ErrorResponse = new ProblemDetails()
        {
            Title = "Unauthorized",
            Detail = errorDetails,
            Status = StatusCode
        };
    }

    public UnauthorizedException(ProblemDetails problemDetails) : base(problemDetails)
    {
        problemDetails.Title ??= Title;
        problemDetails.Status ??= StatusCode;
    }
}
