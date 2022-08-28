using BadWeather.Api.Controllers;
using BadWeather.Application.Contracts;
using BadWeather.Application.Services;
using BadWeather.Domain.Models;
using BadWeather.Tests.Mocks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace BadWeather.Tests.Unit;

public class MetarsControllerUnitTests
{
    private readonly MetarsController _sut;
    
    public MetarsControllerUnitTests()
    {
        var mockMetarProvider = new MockMetarProvider();
        var metarService = new MetarService(mockMetarProvider.Object);

        _sut = new MetarsController(metarService);
    }

    [Fact]
    public async Task CanGetTopGustsInOrder()
    {
        ActionResult<List<Metar>> contentResult = await _sut.GetTop20Gusts("Y");
        
        var metars = (IEnumerable<Metar>)((OkObjectResult)contentResult.Result!).Value!;
        metars = metars.ToList();

        metars.First().StationIcao.Should().Be("YMEN");
        metars.First().WindGustKnots.Should().Be(32);
        metars.Last().StationIcao.Should().Be("YMML");
        metars.Last().WindGustKnots.Should().Be(2);
    }
}