using System.Globalization;
using AutoMapper;
using BadWeather.Application.Contracts;
using CsvHelper;
using BadWeather.Domain.Models;

namespace BadWeather.Application.Services;

public class AviationWeatherCsvMetarProvider : IMetarProvider
{
    private readonly GzipCompressor _gzipCompressor;
    private readonly IMapper _automapper;
    private readonly HttpClient _httpClient;
    private readonly string _csvDownloadUrl = 
        "https://www.aviationweather.gov/adds/dataserver_current/current/metars.cache.csv.gz";

    public AviationWeatherCsvMetarProvider(
        IHttpClientFactory httpClientFactory,
        GzipCompressor gzipCompressor,
        IMapper automapper)
    {
        _gzipCompressor = gzipCompressor;
        _automapper = automapper;
        _httpClient = httpClientFactory.CreateClient();
    }

    public async Task<IList<Metar>> RetrieveMetars()
    {
        Stream csvStream = await DownloadCsvAsStream();
        IList<AviationWeatherCsvMetar> metars = ParseCsvToMetars(csvStream);

        return _automapper.Map<List<Metar>>(metars);
    }

    private async Task<Stream> DownloadCsvAsStream()
    {
        Stream response = await _httpClient.GetStreamAsync(_csvDownloadUrl);
        return  _gzipCompressor.DecompressStream(response);
    }

    private IList<AviationWeatherCsvMetar> ParseCsvToMetars(Stream csvStream)
    {
        using StreamReader csvStreamReader = new StreamReader(csvStream);
        using var csv = new CsvReader(csvStreamReader, CultureInfo.InvariantCulture);

        // Skip to the header index at row 6.
        for (var i = 0; i < 6; i++)
            csv.Read();

        csv.ReadHeader();

        return csv
            .GetRecords<AviationWeatherCsvMetar>()
            .ToList();
    }
}