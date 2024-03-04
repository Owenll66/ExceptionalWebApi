using Microsoft.AspNetCore.Mvc;

namespace ExceptionalWebApi.Responses;

public class BadRequestProblemDetails : ValidationProblemDetails
{
    public BadRequestProblemDetails()
    {
        Title = "Bad Request";
        Status = 400;
    }
}
