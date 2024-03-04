using Microsoft.AspNetCore.Mvc;

namespace ExceptionalWebApi.Responses;

public class InternalServerErrorProblemDetails : ProblemDetails
{
    public InternalServerErrorProblemDetails()
    {
        Title = "Internal Server Error";
        Status = 500;
    }
}
