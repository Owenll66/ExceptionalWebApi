# ExceptionalWebApi
A .net web api library that translates exceptions to consistent http error responses fluently.

## Get Started

In Program.cs file:
```csharp
using ExceptionalWebApi;
//...
app.UseExceptionHandling();
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

You can produce more detailed error by specifying the problem details:
```csharp
throw new BadRequestException(new BadRequestProblemDetails { /* Detail goes here */ });
throw new InternalServerErrorException(new InternalServerErrorProblemDetails() { /* Detail goes here */ });
throw new NotFoundException(new NotFoundProblemDetails() { /* Detail goes here */ })
...
```

The execeptions will be translated to errors in a consistent format in json.