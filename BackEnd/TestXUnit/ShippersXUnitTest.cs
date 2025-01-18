using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;

namespace TestXUnit;

public class ShippersXUnitTest : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public ShippersXUnitTest(WebApplicationFactory<Program> factory)
    {
        Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Local");
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetShippers()
    {
        HttpResponseMessage carga = _client.GetAsync($"/api/Shippers/GetShippers").Result;

        carga.EnsureSuccessStatusCode();

        Assert.NotNull(carga);

        string content = await carga.Content.ReadAsStringAsync();

        content.Should().NotBeNullOrEmpty();
    }
}
