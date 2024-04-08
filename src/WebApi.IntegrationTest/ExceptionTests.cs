using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

namespace WebApi.IntegrationTest;

public class ExceptionTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    private readonly HttpStatusCode[] _handledStatusCodes =
    [
        HttpStatusCode.BadRequest,
        HttpStatusCode.Unauthorized,
        HttpStatusCode.Forbidden,
        HttpStatusCode.NotFound,
        HttpStatusCode.InternalServerError,
        HttpStatusCode.PaymentRequired
    ];

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

        // Act
        var response = await client.GetAsync(url);

        // Assert
        if (_handledStatusCodes.Contains(statusCode))
            Assert.Equal(statusCode, response.StatusCode);
        else
            Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
    }
}
