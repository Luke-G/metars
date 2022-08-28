using System.Net.Http.Json;
using BadWeather.Domain.Models;
using FluentAssertions;
using Xunit;

namespace BadWeather.Tests.Integration;

public class MetarsIntegrationTests 
    : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly CustomWebApplicationFactory<Program> _factory;

    public MetarsIntegrationTests(CustomWebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task GetGustMetars_ReturnsOrderedByGust()
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync("/metars/gust");

        response.EnsureSuccessStatusCode();
        response.Content.Headers.ContentType!.ToString().Should().Be("application/json; charset=utf-8");

        var metars = await response.Content.ReadFromJsonAsync<List<Metar>>();

        metars!.First().StationIcao.Should().Be("YMEN");
        metars!.First().WindGustKnots.Should().Be(32);
        metars!.Last().StationIcao.Should().Be("YMML");
        metars!.Last().WindGustKnots.Should().Be(2);
    }
}