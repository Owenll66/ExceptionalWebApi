using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Text.Json;

namespace WebApi.IntegrationTest;

public class ExceptionTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    

    public ExceptionTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Theory]
    [InlineData(HttpStatusCode.Ambiguous)]
    [InlineData(HttpStatusCode.BadRequest)]
    [InlineData(HttpStatusCode.Unauthorized)]
    [InlineData(HttpStatusCode.Forbidden)]
    [InlineData(HttpStatusCode.NotFound)]
    [InlineData(HttpStatusCode.InternalServerError)]
    [InlineData(HttpStatusCode.PaymentRequired)]
    public async Task GetHttpResponseByStatusCode_ShouldReturnCorrectStatusAndPayload(HttpStatusCode statusCode)
    {
        // Arrange
        var client = _factory.CreateClient();
        var url = "exceptions/" + statusCode;
        var handledStatusCodes = new HttpStatusCode[]
        {
            HttpStatusCode.BadRequest,
            HttpStatusCode.Unauthorized,
            HttpStatusCode.Forbidden,
            HttpStatusCode.NotFound,
            HttpStatusCode.InternalServerError,
            HttpStatusCode.PaymentRequired
        };

        var statusCodeTitle = new Dictionary<int, string?>()
        {
            // StatusCode 300 "Ambiguous" is not handled in ExceptionTestController, which will throw Exception by default,
            // and resulted in "Internal Server Error" message title.
            [300] = "Internal Server Error",
            [400] = "Bad Request",
            [401] = "Unauthorized",
            [403] = "Forbidden",
            [404] = "Not Found",
            [500] = "Internal Server Error",
            [402] = "Payment Required"
        };

        // Act
        var response = await client.GetAsync(url);
        var responseContent = await response.Content.ReadAsStringAsync();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var responsePayload = JsonSerializer.Deserialize<ProblemDetails>(responseContent, options);

        // Assert
        if (handledStatusCodes.Contains(statusCode))
            Assert.Equal(statusCode, response.StatusCode);
        else
            Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);

        Assert.Equal(statusCodeTitle[(int)statusCode], responsePayload?.Title);
    }
}
