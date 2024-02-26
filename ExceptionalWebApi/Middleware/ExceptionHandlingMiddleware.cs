using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using ExceptionalWebApi.Exceptions;
using Microsoft.AspNetCore.Http.HttpResults;

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
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        IActionResult result = exception switch
        {
            InvalidRequestException _ => new BadRequestResult(),
            UnauthorizedException _ => new UnauthorizedResult(),
            ForbiddenException _ => new ForbidResult(),
            NotFoundException _ => new NotFoundResult(),

            _ => new StatusCodeResult(500)
        };

        context.Response.ContentType = "application/json";
        //context.Response.StatusCode = (int)result.StatusCode;

        await context.Response.WriteAsJsonAsync(result.GetType());
    }
}
