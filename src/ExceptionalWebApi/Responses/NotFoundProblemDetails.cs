using Microsoft.AspNetCore.Mvc;

namespace ExceptionalWebApi.Responses;

public class NotFoundProblemDetails : ProblemDetails
{
    public NotFoundProblemDetails()
    {
        Title = "Not Found";
        Status = 404;
    }
}
