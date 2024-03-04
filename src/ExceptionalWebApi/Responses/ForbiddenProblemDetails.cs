using Microsoft.AspNetCore.Mvc;

namespace ExceptionalWebApi.Responses;

public class ForbiddenProblemDetails : ProblemDetails
{
    public ForbiddenProblemDetails()
    {
        Title = "Forbidden";
        Status = 403;
    }
}
