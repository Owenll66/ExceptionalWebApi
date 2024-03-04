using Microsoft.AspNetCore.Mvc;

namespace ExceptionalWebApi.Responses;

public class UnauthorizedProblemDetails : ProblemDetails
{
    public UnauthorizedProblemDetails()
    {
        Title = "Unauthorized";
        Status = 401;
    }
}
