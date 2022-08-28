using BadWeather.Domain.Models;

namespace BadWeather.Application.Filters;

public static class IcaoPrefixFilter
{
    public static IEnumerable<Metar> FilterByIcaoPrefix(this IEnumerable<Metar> queryable, string icaoPrefix)
    {
        return queryable.Where(q => q.StationIcao.StartsWith(icaoPrefix.ToUpperInvariant()));
    }
}