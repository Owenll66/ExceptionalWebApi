using Microsoft.AspNetCore.Mvc;

namespace ExceptionalWebApi.Exceptions;

public class BadRequestException : ApiException
{
    public override int? StatusCode { get; set; } = 400;
    public override string? Title { get; set; } = "Bad Request";

    public BadRequestException(string? errorDetails = null, IDictionary<string, string[]>? errors = null)
    {
        var validationProblemDetails = new ValidationProblemDetails()
        {
            Title = Title,
            Detail = errorDetails,
            Status = StatusCode,
        };

        if (errors != null)
            validationProblemDetails.Errors = errors;

        ErrorResponse = validationProblemDetails;
    }

    public BadRequestException(ValidationProblemDetails validationProblemDetails) : base(validationProblemDetails)
    {
        validationProblemDetails.Title ??= Title;
        validationProblemDetails.Status ??= StatusCode;
    }
}