using BadWeather.Application.Contracts;
using BadWeather.Application.Filters;
using BadWeather.Domain.Models;

namespace BadWeather.Application.Services;

public class MetarService : IMetarService
{
    private readonly IMetarProvider _metarProvider;

    public MetarService(IMetarProvider metarProvider)
    {
        _metarProvider = metarProvider;
    }

    public async Task<IEnumerable<Metar>> GetStorms()
    {
        IList<Metar> allMetars = await _metarProvider.RetrieveMetars();
        return allMetars.WhereStormy();
    }

    public async Task<IEnumerable<Metar>> GetHighestGusts()
    {
        IList<Metar> allMetars = await _metarProvider.RetrieveMetars();
        return allMetars.OrderByDescending(q => q.WindGustKnots);
    }

    public async Task<IEnumerable<Metar>> GetHighestWinds()
    {
        IList<Metar> allMetars = await _metarProvider.RetrieveMetars();
        return allMetars.OrderByDescending(q => q.WindSpeedKnots);
    }

    public async Task<IEnumerable<Metar>> GetLowestVisibility()
    {
        IList<Metar> allMetars = await _metarProvider.RetrieveMetars();
        return allMetars
            .Where(q => q.Visibility != null)
            .OrderBy(q => q.Visibility);
    }
}