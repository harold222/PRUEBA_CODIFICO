using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Text;
using TestXUnit.Models;

namespace TestXUnit;

public class OrderXUnitTest : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public OrderXUnitTest(WebApplicationFactory<Program> factory)
    {
        Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Local");
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task CreateOrder()
    {
        var newOrder = new
        {
            Empid = 1,
            Shipperid = 2,
            Shipname = "Speedy Express",
            Shipaddress = "525 S. Lexington Ave",
            Shipcity = "Seattle",
            Shipcountry = "USA",
            Orderdate = "1996-07-04T05:00:00.000Z",
            Requireddate = "1996-08-01T05:00:00.000Z",
            Shippeddate = "1996-07-16T05:00:00.000Z",
            Freight = 10.5,
            ProductId = 33,
            UnitPrice = 14,
            Quantity = 12,
            Discount = 0.15,
            CustomerId = 1
        };

        var contentPost = new StringContent(JsonConvert.SerializeObject(newOrder), Encoding.UTF8, "application/json");

        HttpResponseMessage carga = _client.PostAsync($"/api/Order/CreateOrder", contentPost).Result;

        carga.EnsureSuccessStatusCode();

        Assert.NotNull(carga);

        string content = await carga.Content.ReadAsStringAsync();

        content.Should().NotBeNullOrEmpty();
        Assert.Contains("id", content);
    }

    [Theory]
    [InlineData("72")]
    public async Task GetClientOrders(string id)
    {
        HttpResponseMessage carga = _client.GetAsync($"/api/Order/GetOrderByClient/{id}").Result;

        carga.EnsureSuccessStatusCode();

        Assert.NotNull(carga);

        string content = await carga.Content.ReadAsStringAsync();

        content.Should().NotBeNullOrEmpty();

        List<OrdersResponse>? result = System.Text.Json.JsonSerializer.Deserialize<List<OrdersResponse>>(content);

        Assert.False(string.IsNullOrWhiteSpace(result.FirstOrDefault()?.nombre));
    }

    [Fact]
    public async Task GetNextOrder()
    {
        HttpResponseMessage carga = _client.GetAsync($"/api/Order/NextOrder").Result;

        carga.EnsureSuccessStatusCode();

        string content = await carga.Content.ReadAsStringAsync();

        content.Should().NotBeNullOrEmpty();

        List<GetNextOrderResponse>? result = System.Text.Json.JsonSerializer.Deserialize<List<GetNextOrderResponse>>(content);

        var findCustomer = result.Find(x => x.nombre == "Customer AHPOP");

        findCustomer.Should().NotBeNull();

        findCustomer.ultimaCompra.Should().Be("2008-02-04 00:00:00.000");
        findCustomer.prediccion.Should().Be("2008-03-23 00:00:00.000");
    }
}