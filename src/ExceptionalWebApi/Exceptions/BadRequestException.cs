using Microsoft.AspNetCore.Mvc;

namespace ExceptionalWebApi.Exceptions;

public class BadRequestException : ApiException
{
    public override int? StatusCode { get; set; } = 400;

    public BadRequestException(object errorResponse, int? statusCode = null)
    {
        ErrorResponse = errorResponse;
        StatusCode = statusCode;
    }

    public BadRequestException(ValidationProblemDetails? errorResponse = null)
    {
        ErrorResponse = errorResponse ?? new ValidationProblemDetails() { Title = "Bad Request", Status = StatusCode };
    }
}