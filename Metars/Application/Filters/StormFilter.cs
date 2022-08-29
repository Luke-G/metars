using Metars.Domain.Models;

namespace Metars.Application.Filters;

public static class StormFilter
{
    public static IEnumerable<Metar> WhereStormy(this IEnumerable<Metar> queryable)
    {
        var stormKeys = new string[]
        {
            "VCTS", "TSRA", "TSGR"
        };

        return queryable.Where(q => stormKeys.Any(k => q.Text.Contains(k)));
    }
}