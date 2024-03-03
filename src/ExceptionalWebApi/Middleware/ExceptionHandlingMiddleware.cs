using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using ExceptionalWebApi.Exceptions;
using ExceptionalWebApi.Extensions;

namespace ExceptionalWebApi.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
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
        catch (AppException ex)
        {
            var apiException = ex.CovertToApiException();
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = apiException.statusCode;
            await context.Response.WriteAsJsonAsync(apiException.payload);
        }
    }
}
