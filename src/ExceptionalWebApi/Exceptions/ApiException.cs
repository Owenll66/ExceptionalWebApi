using Microsoft.AspNetCore.Mvc;

namespace ExceptionalWebApi.Exceptions;

public class ApiException : Exception
{
    public ProblemDetails ProblemDetails { get; set; }

    public ApiException()
    {
        ProblemDetails = new ProblemDetails();
    }

    public ApiException(ProblemDetails problemDetails)
    {
        ProblemDetails = problemDetails;
    }
}