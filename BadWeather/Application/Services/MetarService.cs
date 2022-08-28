using BadWeather.Application.Contracts;
using BadWeather.Application.Filters;
using BadWeather.Domain.Models;
using Microsoft.Extensions.Caching.Memory;

namespace BadWeather.Application.Services;

public class MetarService : IMetarService
{
    private readonly IMetarProvider _metarProvider;
    private readonly IMemoryCache _memoryCache;

    public MetarService(IMetarProvider metarProvider, IMemoryCache memoryCache)
    {
        _metarProvider = metarProvider;
        _memoryCache = memoryCache;
    }

    public async Task<IEnumerable<Metar>> GetStorms()
    {
        IEnumerable<Metar> allMetars = await GetMetars();
        return allMetars.WhereStormy();
    }

    public async Task<IEnumerable<Metar>> GetHighestGusts()
    {
        IEnumerable<Metar> allMetars = await GetMetars();
        return allMetars.OrderByDescending(q => q.WindGustKnots);
    }

    public async Task<IEnumerable<Metar>> GetHighestWinds()
    {
        IEnumerable<Metar> allMetars = await GetMetars();
        return allMetars.OrderByDescending(q => q.WindSpeedKnots);
    }

    public async Task<IEnumerable<Metar>> GetLowestVisibility()
    {
        IEnumerable<Metar> allMetars = await GetMetars();
        return allMetars
            .Where(q => q.Visibility != null)
            .OrderBy(q => q.Visibility);
    }

    private async Task<IEnumerable<Metar>> GetMetars()
    {
        _memoryCache.TryGetValue("metars", out IList<Metar> cachedMetars);

        if (cachedMetars is not null)
            return cachedMetars;
        
        IList<Metar> metars = await _metarProvider.RetrieveMetars();
        
        _memoryCache.Set("metars", metars, TimeSpan.FromMinutes(5));

        return metars;
    }
}