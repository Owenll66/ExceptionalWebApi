using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Text;
using System.Text.Json;

namespace WebApi.IntegrationTest;

public class ExceptionTests
    : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public ExceptionTests(WebApplicationFactory<Program> factory)
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

        var payload = new { Title = "Exception Test", StatusCode = statusCode, };

        var serializedPayload = JsonSerializer.Serialize(payload);
        var httpContent = new StringContent(serializedPayload, Encoding.UTF8, "application/json");

        // Act
        var response = await client.PostAsync(url, httpContent);
        var responseContent = await response.Content.ReadAsStringAsync();

        // Assert
        Assert.Equal(statusCode, response.StatusCode);
        Assert.Equal(serializedPayload, responseContent);
    }
}