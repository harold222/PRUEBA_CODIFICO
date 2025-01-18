using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using TestXUnit.Models;

namespace TestXUnit;

public class ProductsXUnitTest : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public ProductsXUnitTest(WebApplicationFactory<Program> factory)
    {
        Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Local");
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetProducts()
    {
        HttpResponseMessage carga = _client.GetAsync($"/api/Products/GetProducts").Result;

        carga.EnsureSuccessStatusCode();

        Assert.NotNull(carga);

        string content = await carga.Content.ReadAsStringAsync();

        content.Should().NotBeNullOrEmpty();

        Assert.IsAssignableFrom<IEnumerable<GetProductsResponse>>(JsonConvert.DeserializeObject<IEnumerable<GetProductsResponse>>(content));
    }
}
