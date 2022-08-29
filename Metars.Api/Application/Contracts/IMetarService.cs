using Metars.Api.Domain.Models;

namespace Metars.Api.Application.Contracts;

public interface IMetarService
{
    Task<IEnumerable<Metar>> GetStorms();
    Task<IEnumerable<Metar>> GetHighestGusts();
    Task<IEnumerable<Metar>> GetHighestWinds();
    Task<IEnumerable<Metar>> GetLowestVisibility();
}