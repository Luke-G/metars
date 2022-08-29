using Metars.Api.Application.Contracts;
using Metars.Api.Domain.Models;
using Metars.Api.Infrastructure.Database;

namespace Metars.Api.Application.Services;

public class MetarImportService : IMetarImportService
{
    private readonly IMetarProvider _metarProvider;
    private readonly ApplicationDbContext _dbContext;

    public MetarImportService(IMetarProvider metarProvider, ApplicationDbContext dbContext)
    {
        _metarProvider = metarProvider;
        _dbContext = dbContext;
    }

    public async Task ImportAsync()
    {
        IList<Metar> metars = await _metarProvider.RetrieveMetars();
        _dbContext.Metars.AddRange(metars);
        await _dbContext.SaveChangesAsync();
    }
}