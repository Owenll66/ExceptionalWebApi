namespace ExceptionalWebApi.Exceptions;

public record ApiException(int statusCode, object? payload);
