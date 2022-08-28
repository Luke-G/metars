using BadWeather.Domain.Models;

namespace BadWeather.Application.Contracts;

public interface IMetarService
{
    Task<IEnumerable<Metar>> GetStorms();
    Task<IEnumerable<Metar>> GetHighestGusts();
    Task<IEnumerable<Metar>> GetHighestWinds();
    Task<IEnumerable<Metar>> GetLowestVisibility();
}