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

### Define your own custom exceptions:
```csharp
public class CustomException : ApiException
{
    public override int? StatusCode { get; set; } = 402;
    public override string? Title { get; set; } = "Payment Required";

    public CustomException(string? errorDetails = null)
    {
        ErrorResponse = new ProblemDetails()
        {
            Title = Title,
            Detail = errorDetails,
            Status = StatusCode
        };
    }

    public CustomException(ProblemDetails problemDetails) : base(problemDetails)
    {
        problemDetails.Title ??= Title;
        problemDetails.Status ??= StatusCode;
    }
}
```

