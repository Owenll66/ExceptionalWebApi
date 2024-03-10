using Microsoft.AspNetCore.Mvc;

namespace ExceptionalWebApi.Exceptions;

public class UnauthorizedException : ApiException
{
    public override int? StatusCode { get; set; } = 401;

    public UnauthorizedException(object errorResponse, int? statusCode = null)
    {
        ErrorResponse = errorResponse;
        StatusCode = statusCode;
    }

    public UnauthorizedException(ProblemDetails? problemDetails = null)
    {
        ErrorResponse = problemDetails ?? new ProblemDetails() { Title = "Unauthorized", Status = StatusCode };
    }
}
