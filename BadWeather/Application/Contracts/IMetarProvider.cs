using BadWeather.Domain.Models;

namespace BadWeather.Application.Contracts;

public interface IMetarProvider
{
    Task<IList<Metar>> RetrieveMetars();
}