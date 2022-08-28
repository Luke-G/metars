namespace BadWeather.Application.Contracts;

public interface IMetarImportService
{
    Task ImportAsync();
}