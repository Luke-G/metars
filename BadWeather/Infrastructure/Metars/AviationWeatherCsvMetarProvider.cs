using System.Globalization;
using System.IO.Compression;
using BadWeather.Application.Contracts;
using CsvHelper;
using BadWeather.Domain.Models;

namespace BadWeather.Infrastructure.Metars;

public class AviationWeatherCsvMetarProvider : IMetarProvider
{
    private readonly HttpClient _httpClient;
    private readonly string _csvDownloadUrl = 
        "https://www.aviationweather.gov/adds/dataserver_current/current/metars.cache.csv.gz";

    public AviationWeatherCsvMetarProvider(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient();
    }

    public async Task<IList<Metar>> RetrieveMetars()
    {
        await using Stream csvStream = await DownloadCsvAsStream();
        return ParseMetarsFromCsv(csvStream);
    }

    private async Task<Stream> DownloadCsvAsStream()
    {
        Stream response = await _httpClient.GetStreamAsync(_csvDownloadUrl);
        return new GZipStream(response, CompressionMode.Decompress);
    }

    private IList<Metar> ParseMetarsFromCsv(Stream csvStream)
    {
        using StreamReader csvStreamReader = new StreamReader(csvStream);
        using var csv = new CsvReader(csvStreamReader, CultureInfo.InvariantCulture);
        csv.Context.RegisterClassMap<MetarCsvClassMap>();

        // Skip to the header index at row 6.
        for (var i = 0; i < 6; i++)
            csv.Read();

        csv.ReadHeader();

        return csv
            .GetRecords<Metar>()
            .ToList();
    }
}