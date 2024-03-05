using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using ExceptionalWebApi.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace ExceptionalWebApi.Middleware;

public class ApiExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ApiExceptionHandlingMiddleware> _logger;

    public ApiExceptionHandlingMiddleware(RequestDelegate next, ILogger<ApiExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ApiException ex)
        {
            context.Response.ContentType = "application/json";

            if (ex.ProblemDetails.Status.HasValue)
                context.Response.StatusCode = ex.ProblemDetails.Status.Value;

            if (ex.ProblemDetails is ValidationProblemDetails validationProblemDetails)
                await context.Response.WriteAsJsonAsync(validationProblemDetails);
            else
                await context.Response.WriteAsJsonAsync(ex.ProblemDetails);
        }
    }
}
