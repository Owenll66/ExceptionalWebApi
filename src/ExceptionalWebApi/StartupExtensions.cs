using ExceptionalWebApi.Middleware;
using Microsoft.AspNetCore.Builder;

namespace ExceptionalWebApi
{
    public static class StartupExtensions
    {
        public static IApplicationBuilder UseExceptionHandling(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}
