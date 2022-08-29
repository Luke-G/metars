using AutoMapper;
using Metars.Api.Presentation.Controllers;
using Metars.Api.Application.Mappings;
using Metars.Api.Application.Responses;
using Metars.Api.Application.Services;
using FluentAssertions;
using Metars.Tests.Mocks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Moq;
using Xunit;

namespace Metars.Tests.Unit;

public class BadWeatherControllerUnitTests
{
    private readonly BadWeatherController _sut;
    
    public BadWeatherControllerUnitTests()
    {
        var mockMetarProvider = new MockMetarProvider();
        var metarService = new MetarService(mockMetarProvider.Object, new Mock<IMemoryCache>().Object);
        
        var autoMapperConfig = new MapperConfiguration(config =>
        {
            config.AddProfile<MetarProfile>();
        });

        var automapper = new Mapper(autoMapperConfig);

        _sut = new BadWeatherController(metarService, automapper);
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