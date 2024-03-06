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
    public async Task GetHttpResponseByStatusCode_ShouldReturnCorrectStatus(HttpStatusCode statusCode, string payloadProp1, int payloadProp2)
    {
        // Arrange
        var client = _factory.CreateClient();
        var url = "exceptions/" + statusCode;

        // Act
        var response = await client.PostAsJsonAsync(url, new RequestPayload { Prop1 = payloadProp1, Prop2 = payloadProp2 });
        var responseContent = await response.Content.ReadAsStringAsync();

        var payLoad = JsonSerializer.Deserialize<RequestPayload>(responseContent);

        // Assert
        Assert.Equal(statusCode, response.StatusCode);
        Assert.Equal(payloadProp1, payLoad!.Prop1);
        Assert.Equal(payloadProp2, payLoad.Prop2);
    }

    private class RequestPayload
    {
        public string? Prop1 { get; set; }
        public int Prop2 { get; set; }
    }
}
