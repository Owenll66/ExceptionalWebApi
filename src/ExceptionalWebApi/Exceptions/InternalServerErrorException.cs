using Microsoft.AspNetCore.Mvc;

namespace ExceptionalWebApi.Exceptions;

public class InternalServerErrorException : ApiException
{
    public override int? StatusCode { get; set; } = 500;

    public InternalServerErrorException(string? errorDetails = null)
    {
        ErrorResponse = new ProblemDetails()
        {
            Title = "Internal Server Error",
            Detail = errorDetails,
            Status = StatusCode
        };
    }

    public InternalServerErrorException(ProblemDetails problemDetails) : base(problemDetails)
    {
    }
}
