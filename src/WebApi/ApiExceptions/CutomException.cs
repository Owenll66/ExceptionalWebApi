using Microsoft.AspNetCore.Mvc;

namespace ExceptionalWebApi.Exceptions;

public class CustomException : ApiException
{
    public override int? StatusCode { get; set; } = 402;
    public override string? Title { get; set; } = "Payment Required";

    public CustomException(string? errorDetails = null)
    {
        ErrorResponse = new ProblemDetails()
        {
            Title = Title,
            Detail = errorDetails,
            Status = StatusCode
        };
    }

    public CustomException(ProblemDetails problemDetails) : base(problemDetails)
    {
        problemDetails.Title ??= Title;
        problemDetails.Status ??= StatusCode;
    }
}