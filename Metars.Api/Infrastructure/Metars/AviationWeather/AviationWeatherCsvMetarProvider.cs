using System.Globalization;
using System.IO.Compression;
using AutoMapper;
using CsvHelper;
using Metars.Api.Application.Contracts;
using Metars.Api.Domain.Models;

namespace Metars.Api.Infrastructure.Metars.AviationWeather;

public class AviationWeatherCsvMetarProvider : IMetarProvider
{
    private readonly IMapper _automapper;
    private readonly HttpClient _httpClient;
    private readonly string _csvDownloadUrl = 
        "https://www.aviationweather.gov/adds/dataserver_current/current/metars.cache.csv.gz";

    public AviationWeatherCsvMetarProvider(IHttpClientFactory httpClientFactory, IMapper automapper)
    {
        _automapper = automapper;
        _httpClient = httpClientFactory.CreateClient();
    }

    public async Task<IList<Metar>> RetrieveMetars()
    {
        await using Stream csvStream = await DownloadCsvAsStream();
        IList<AviationWeatherCsvMetar> metars = ParseMetarsFromCsv(csvStream);

        return _automapper.Map<IList<Metar>>(metars);
    }

    private async Task<Stream> DownloadCsvAsStream()
    {
        Stream response = await _httpClient.GetStreamAsync(_csvDownloadUrl);
        return new GZipStream(response, CompressionMode.Decompress);
    }

    private IList<AviationWeatherCsvMetar> ParseMetarsFromCsv(Stream csvStream)
    {
        using StreamReader csvStreamReader = new StreamReader(csvStream);
        using var csv = new CsvReader(csvStreamReader, CultureInfo.InvariantCulture);
        csv.Context.RegisterClassMap<MetarCsvClassMap>();

        // Skip to the header index at row 6.
        for (var i = 0; i < 6; i++)
            csv.Read();

        csv.ReadHeader();

        return csv
            .GetRecords<AviationWeatherCsvMetar>()
            .ToList();
    }
}