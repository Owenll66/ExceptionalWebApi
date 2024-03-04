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

        // Act
        var response = await client.GetAsync(url);
        var responseContent = await response.Content.ReadAsStringAsync();

        // Assert
        Assert.Equal(statusCode, response.StatusCode);
        if (response.StatusCode == HttpStatusCode.BadRequest)
        {
            var validationProblemDetails = JsonSerializer.Deserialize<ValidationProblemDetails>(responseContent);
            Assert.IsType<ValidationProblemDetails>(validationProblemDetails);
        }
        else
        {
            var validationProblemDetails = JsonSerializer.Deserialize<ProblemDetails>(responseContent);
            Assert.IsType<ProblemDetails>(validationProblemDetails);
        }
    }
}