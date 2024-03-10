using Microsoft.AspNetCore.Mvc;

namespace ExceptionalWebApi.Exceptions;

public class NotFoundException : ApiException
{
    public override int? StatusCode { get; set; } = 404;

    public NotFoundException(object errorResponse, int? statusCode = null)
    {
        ErrorResponse = errorResponse;
        StatusCode = statusCode;
    }

    public NotFoundException(ProblemDetails? problemDetails = null)
    {
        ErrorResponse = problemDetails ?? new ProblemDetails() { Title = "Not Found", Status = StatusCode };
    }
}
