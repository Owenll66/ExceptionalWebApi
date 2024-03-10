# ExceptionalWebApi

A .net web api library that translates exceptions to consistent http error responses fluently.

More new features and supported exceptions can be requested through [issues](https://github.com/Owenll66/ExceptionalWebApi/issues) in this repository.

If you wish to contribute to this repository, please create an issue and or pick up an existing issue and lets discuss first.

Nuget Package: https://www.nuget.org/packages?q=ExceptionalWebapi

## Get Started

In Program.cs file:
```csharp
using ExceptionalWebApi;
//...
app.UseApiExceptionHandling();
```

In any layer of your code, throw the exception as below:
```
throw new BadRequestException();
```
This will be transalated to json response:
```json
{
  "title": "Bad Request",
  "status": 400,
  "errors": {}
}
```

### Produce more detailed error by specifying the problem details:
```csharp
throw new BadRequestException(new BadRequestProblemDetails { /* Detail goes here */ });
throw new InternalServerErrorException(new InternalServerErrorProblemDetails() { /* Detail goes here */ });
throw new NotFoundException(new NotFoundProblemDetails() { /* Detail goes here */ })
```

### Pass any type of object to be serilized in the http response:
```csharp
throw new BadRequestException(new CustomErrorResponse { Prop1 = "something", Prop2 = 100 });
throw new InternalServerErrorException(new { Prop1 = "error", Prop2 = 123 });
```

### Define your own custom exceptions:
```csharp
public class CustomException : ApiException
{
    public override int? StatusCode { get; set; } = 402;

    public CustomException(object errorResponse, int? statusCode = null)
    {
        ErrorResponse = errorResponse;
        StatusCode = statusCode;
    }

    public CustomException(ProblemDetails? errorResponse = null)
    {
        ErrorResponse = errorResponse ?? new ProblemDetails() { Title = "Bad Request", Status = StatusCode };
    }
}
```

