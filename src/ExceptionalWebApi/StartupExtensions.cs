using ExceptionalWebApi.Middleware;
using Microsoft.AspNetCore.Builder;

namespace ExceptionalWebApi
{
    public static class StartupExtensions
    {
        public static IApplicationBuilder UseApiExceptionHandling(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ApiExceptionHandlingMiddleware>();
        }
    }
}
