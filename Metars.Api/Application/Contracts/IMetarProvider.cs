using Metars.Api.Domain.Models;

namespace Metars.Api.Application.Contracts;

public interface IMetarProvider
{
    Task<IList<Metar>> RetrieveMetars();
}