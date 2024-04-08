using ExceptionalWebApi.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ExceptionalWebApi.Middleware;

public class ApiExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ApiExceptionHandlingMiddleware> _logger;
    private readonly ExceptionHandlingOptions _options;

    public ApiExceptionHandlingMiddleware(RequestDelegate next, ILogger<ApiExceptionHandlingMiddleware> logger, IOptions<ExceptionHandlingOptions> options)
    {
        _next = next;
        _logger = logger;
        _options = options.Value;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ApiException apiException)
        {
            context.Response.ContentType = "application/json";

            if (apiException.StatusCode.HasValue)
                context.Response.StatusCode = apiException.StatusCode.Value;

            await context.Response.WriteAsJsonAsync(apiException.ErrorResponse);
        }
        catch (Exception ex) when (_options.CatchGeneralException)
        {
            _logger.LogError(ex, ex.Message);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = 500;
            var internalServerError = new InternalServerErrorException();

            await context.Response.WriteAsJsonAsync(internalServerError.ErrorResponse);
        }
    }
}
