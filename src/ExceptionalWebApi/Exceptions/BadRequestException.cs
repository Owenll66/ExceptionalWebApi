using Microsoft.AspNetCore.Mvc;

namespace ExceptionalWebApi.Exceptions;

public class BadRequestException : ApiException
{
    public override int? StatusCode { get; set; } = 400;

    public BadRequestException(string? errorDetails = null, IDictionary<string, string[]>? errors = null)
    {
        var validationProblemDetails = new ValidationProblemDetails()
        {
            Title = "Bad Request",
            Detail = errorDetails,
            Status = StatusCode,
        };

        if (errors != null)
            validationProblemDetails.Errors = errors;

        ErrorResponse = validationProblemDetails;
    }

    public BadRequestException(ValidationProblemDetails errorResponse) : base(errorResponse)
    {
    }
}