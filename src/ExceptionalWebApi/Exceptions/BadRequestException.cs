using Microsoft.AspNetCore.Mvc;

namespace ExceptionalWebApi.Exceptions;

public class BadRequestException : AppException
{
    public BadRequestException(string? title, string? detail, string? instance)
    {
        ExceptionObject = new ValidationProblemDetails { Title = title, Detail = detail, Instance = instance, Status = 400 };
    }

    public BadRequestException(ValidationProblemDetails? validationError)
    {
        ExceptionObject = validationError ?? new ValidationProblemDetails { Status = 400 };
    }
}