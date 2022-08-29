using Metars.Domain.Models;

namespace Metars.Application.Contracts;

public interface IMetarProvider
{
    Task<IList<Metar>> RetrieveMetars();
}