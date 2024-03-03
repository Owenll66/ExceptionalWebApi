using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Text;
using System.Text.Json;

namespace WebApi.IntegrationTest;

public class HttpExceptionTests
    : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public HttpExceptionTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Theory]
    [InlineData(HttpStatusCode.BadRequest)]
    [InlineData(HttpStatusCode.Unauthorized)]
    [InlineData(HttpStatusCode.Forbidden)]
    [InlineData(HttpStatusCode.NotFound)]
    [InlineData(HttpStatusCode.InternalServerError)]
    public async Task GetHttpResponseByStatusCode_ShouldReturnCorrectStatus(HttpStatusCode statusCode)
    {
        // Arrange
        var client = _factory.CreateClient();
        var url = "exceptions/" + statusCode;

        var httpContent = BuildRequestContent("test");

        // Act
        var response = await client.PostAsync(url, httpContent);

        // Assert
        Assert.Equal(statusCode, response.StatusCode);
    }

    public static StringContent BuildRequestContent<T>(T content)
    {
        string serialized = JsonSerializer.Serialize(content);

        return new StringContent(serialized, Encoding.UTF8, "application/json");
    }
}