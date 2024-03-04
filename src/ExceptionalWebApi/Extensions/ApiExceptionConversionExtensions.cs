using ExceptionalWebApi.Exceptions;
using Microsoft.AspNetCore.Http;

namespace ExceptionalWebApi.Extensions
{
    public static class ApiExceptionConversionExtensions
    {
        public static ApiException CovertToApiException(this AppException exception) => exception switch
        {
            BadRequestException _ => new ApiException(StatusCodes.Status400BadRequest, exception.ExceptionObject),
            UnauthorizedException _ => new ApiException(StatusCodes.Status401Unauthorized, exception.ExceptionObject),
            ForbiddenException _ => new ApiException(StatusCodes.Status403Forbidden, exception.ExceptionObject),
            NotFoundException _ => new ApiException(StatusCodes.Status404NotFound, exception.ExceptionObject),

            _ => new ApiException(StatusCodes.Status500InternalServerError, exception.ExceptionObject)
        };
    }
}
