namespace Metars.Api.Application.Contracts;

public interface IMetarImportService
{
    Task ImportAsync();
}