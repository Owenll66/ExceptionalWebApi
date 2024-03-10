using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http.Json;
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
    [InlineData(HttpStatusCode.BadRequest, "testProp1", 1)]
    [InlineData(HttpStatusCode.Unauthorized, "testProp2", 2)]
    [InlineData(HttpStatusCode.Forbidden, "testProp3", 3)]
    [InlineData(HttpStatusCode.NotFound, "testProp4", 4)]
    [InlineData(HttpStatusCode.InternalServerError, "testProp5", 5)]
    [InlineData(HttpStatusCode.PaymentRequired, "testProp6", 6)]
    public async Task GetHttpResponseByStatusCode_ShouldReturnCorrectStatusAndPayload(HttpStatusCode statusCode, string payloadProp1, int payloadProp2)
    {
        // Arrange
        var client = _factory.CreateClient();
        var url = "exceptions/" + statusCode;

        // Act
        var response = await client.PostAsJsonAsync(url, new RequestPayload { Prop1 = payloadProp1, Prop2 = payloadProp2 });
        var responseContent = await response.Content.ReadAsStringAsync();

        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var responsePayLoad = JsonSerializer.Deserialize<RequestPayload>(responseContent, options);

        // Assert
        Assert.Equal(statusCode, response.StatusCode);
        Assert.Equal(payloadProp1, responsePayLoad!.Prop1);
        Assert.Equal(payloadProp2, responsePayLoad.Prop2);
    }

    [Theory]
    [InlineData(HttpStatusCode.BadRequest)]
    [InlineData(HttpStatusCode.Unauthorized)]
    [InlineData(HttpStatusCode.Forbidden)]
    [InlineData(HttpStatusCode.NotFound)]
    [InlineData(HttpStatusCode.InternalServerError)]
    [InlineData(HttpStatusCode.PaymentRequired)]
    public async Task GetHttpResponseByStatusCode_ShouldReturnCorrectStatus(HttpStatusCode statusCode)
    {
        // Arrange
        var client = _factory.CreateClient();
        var url = "exceptions/" + statusCode;

        // Act
        var response = await client.PostAsync(url, null);

        // Assert
        Assert.Equal(statusCode, response.StatusCode);
    }

    private class RequestPayload
    {
        public string? Prop1 { get; set; }
        public int Prop2 { get; set; }
    }
}
