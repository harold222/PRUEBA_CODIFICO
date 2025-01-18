using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using TestXUnit.Models;

namespace TestXUnit;

public class EmployeesXUnitTest : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public EmployeesXUnitTest(WebApplicationFactory<Program> factory)
    {
        Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Local");
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetEmployees()
    {
        HttpResponseMessage carga = _client.GetAsync($"/api/Employees/GetEmployees").Result;

        carga.EnsureSuccessStatusCode();

        Assert.NotNull(carga);

        string content = await carga.Content.ReadAsStringAsync();

        content.Should().NotBeNullOrEmpty();

        List<GetEmployeesResponse>? result = System.Text.Json.JsonSerializer.Deserialize<List<GetEmployeesResponse>>(content);

        Assert.Equal(9, result.Count);
    }
}
