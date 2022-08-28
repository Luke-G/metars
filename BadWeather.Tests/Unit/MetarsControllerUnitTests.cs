using BadWeather.Api.Controllers;
using BadWeather.Application.Contracts;
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
        var mockLogger = new Mock<ILogger<MetarsController>>();
        var mockMetarProvider = new Mock<IMetarProvider>();

        mockMetarProvider
            .Setup(m => m.RetrieveMetars())
            .ReturnsAsync(MockMetarProvider.GetMockMetars());

        _sut = new MetarsController(mockLogger.Object, mockMetarProvider.Object);
    }

    [Fact]
    public async Task CanGetTopGustsInOrder()
    {
        ActionResult<List<Metar>> contentResult = await _sut.GetTop20Gusts();
        
        var metars = (List<Metar>)((OkObjectResult)contentResult.Result!).Value!;

        metars.First().StationIcao.Should().Be("YMEN");
        metars.First().WindGustKnots.Should().Be(32);
        metars.Last().StationIcao.Should().Be("YMML");
        metars.Last().WindGustKnots.Should().Be(2);
    }
}