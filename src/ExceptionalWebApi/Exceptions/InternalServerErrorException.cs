using Microsoft.AspNetCore.Mvc;

namespace ExceptionalWebApi.Exceptions;

public class InternalServerErrorException : ApiException
{
    public override int? StatusCode { get; set; } = 500;

    public InternalServerErrorException(object errorResponse, int? statusCode = null)
    {
        ErrorResponse = errorResponse;
        StatusCode = statusCode;
    }

    public InternalServerErrorException(ProblemDetails? problemDetails = null)
    {
        ErrorResponse = problemDetails ?? new ProblemDetails() { Title = "Internal Server Error", Status = StatusCode };
    }
}
