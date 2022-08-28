using System.Net;
using AutoMapper;
using BadWeather.Application.Mappings;
using BadWeather.Domain.Models;
using BadWeather.Infrastructure.Metars;
using FluentAssertions;
using Moq;
using Moq.Protected;
using Xunit;

namespace BadWeather.Tests.Unit;

public class AviationWeatherCsvMetarProviderUnitTests
{
    private readonly AviationWeatherCsvMetarProvider _sut;

    public AviationWeatherCsvMetarProviderUnitTests()
    {
        var autoMapperConfig = new MapperConfiguration(config =>
        {
            config.AddProfile<MetarProfile>();
        });

        var automapper = new Mapper(autoMapperConfig);
        
        // Setup mock HTTP client
        var mockHttpClientFactory = new Mock<IHttpClientFactory>();
        var mockHttpMessageHandler = new Mock<HttpMessageHandler>();

        var gzipCsvStream = File.Open(Path.Join("Resources", "metars.cache.csv.gz"), FileMode.Open);

        mockHttpMessageHandler.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StreamContent(gzipCsvStream),
            });
 
        var client = new HttpClient(mockHttpMessageHandler.Object);
        mockHttpClientFactory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(client);
        
        _sut = new AviationWeatherCsvMetarProvider(mockHttpClientFactory.Object, automapper);
    }

    [Fact]
    public async Task CanGetMetars_When_ApiSuccess()
    {
        IList<Metar> metars = await _sut.RetrieveMetars();
        metars.Count.Should().BeGreaterThan(0);

        var firstMetar = metars.First();
        firstMetar.FlightCategory.Should().Be("LIFR");
        firstMetar.ObservationTime.Should().Be("2022-08-27T13:42:00Z");
        firstMetar.StationIcao.Should().Be("PAZK");
        firstMetar.Text.Should().Be("PAZK 271342Z AUTO 00000KT 10SM -RA OVC003 06/05 A2961 RMK AO2 P0001");
        firstMetar.Visibility.Should().Be(10);
        firstMetar.WindDirectionDegrees.Should().Be(0);
        firstMetar.WindGustKnots.Should().Be(0);
        firstMetar.WindSpeedKnots.Should().Be(0);
        firstMetar.AltimeterInHg.Should().Be(29.610237000000001);
    }
}