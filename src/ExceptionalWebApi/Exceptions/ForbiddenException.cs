using Microsoft.AspNetCore.Mvc;

namespace ExceptionalWebApi.Exceptions;

public class ForbiddenException : ApiException
{
    public override int? StatusCode { get; set; } = 403;

    public ForbiddenException(object errorResponse, int? statusCode = null)
    {
        ErrorResponse = errorResponse;
        StatusCode = statusCode;
    }

    public ForbiddenException(ProblemDetails? problemDetails = null)
    {
        ErrorResponse = problemDetails ?? new ProblemDetails() { Title = "Forbidden", Status = StatusCode };
    }
}
