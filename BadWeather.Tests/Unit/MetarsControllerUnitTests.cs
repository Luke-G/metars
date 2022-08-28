using AutoMapper;
using BadWeather.Api.Controllers;
using BadWeather.Application.Contracts;
using BadWeather.Application.Mappings;
using BadWeather.Application.Responses;
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
        
        var autoMapperConfig = new MapperConfiguration(config =>
        {
            config.AddProfile<MetarProfile>();
        });

        var automapper = new Mapper(autoMapperConfig);

        _sut = new MetarsController(metarService, automapper);
    }

    [Fact]
    public async Task CanGetTopGustsInOrder()
    {
        ActionResult<List<MetarResponse>> contentResult = await _sut.GetTop20Gusts("Y");
        
        var metars = (IEnumerable<MetarResponse>)((OkObjectResult)contentResult.Result!).Value!;
        metars = metars.ToList();

        metars.First().StationIcao.Should().Be("YMEN");
        metars.First().WindGustKnots.Should().Be(32);
        metars.Last().StationIcao.Should().Be("YMML");
        metars.Last().WindGustKnots.Should().Be(2);
    }
}