using BadWeather.Application.Contracts;
using BadWeather.Domain.Models;

namespace BadWeather.Tests.Mocks;

public class MockMetarProvider : IMetarProvider
{
    public static IList<Metar> GetMockMetars()
    {
        return new List<Metar>
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
    }

    public Task<IList<Metar>> RetrieveMetars()
    {
        return Task.FromResult(GetMockMetars());
    }
}