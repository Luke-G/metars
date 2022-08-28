using BadWeather.Application.Contracts;
using BadWeather.Domain.Models;
using Moq;

namespace BadWeather.Tests.Mocks;

public class MockMetarProvider : Mock<IMetarProvider>, IMetarProvider
{
    public MockMetarProvider()
    {
        Setup(m => m.RetrieveMetars())
            .ReturnsAsync(RetrieveMetars().Result);
    }

    public Task<IList<Metar>> RetrieveMetars()
    {
        IList<Metar> metars = new List<Metar>
        {
            new Metar
            {
                StationIcao = "EGCC",
                WindGustKnots = 24,
            },
            new Metar
            {
                StationIcao = "EGNT",
                WindGustKnots = 9,
            },
            new Metar
            {
                StationIcao = "YMEN",
                WindGustKnots = 32,
            },
            new Metar
            {
                StationIcao = "YMML",
                WindGustKnots = 2,
            }
        };

        return Task.FromResult(metars);
    }
}