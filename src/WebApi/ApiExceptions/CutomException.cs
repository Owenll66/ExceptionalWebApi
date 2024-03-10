using Microsoft.AspNetCore.Mvc;

namespace ExceptionalWebApi.Exceptions;

public class CustomException : ApiException
{
    public override int? StatusCode { get; set; } = 9999;

    public CustomException(object errorResponse, int? statusCode = null)
    {
        ErrorResponse = errorResponse;
        StatusCode = statusCode;
    }

    public CustomException(ProblemDetails? errorResponse = null)
    {
        ErrorResponse = errorResponse ?? new ProblemDetails() { Title = "Bad Request", Status = StatusCode };
    }
}