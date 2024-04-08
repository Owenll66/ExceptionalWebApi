using ExceptionalWebApi.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;

namespace ExceptionalWebApi
{
    public static class StartupExtensions
    {
        public static IApplicationBuilder UseApiExceptionHandling(this IApplicationBuilder builder, Action<ExceptionHandlingOptions>? options = null)
        {
            var configOptions = new ExceptionHandlingOptions();
            options?.Invoke(configOptions);

            return builder.UseMiddleware<ApiExceptionHandlingMiddleware>(Options.Create(configOptions));
        }
    }
}