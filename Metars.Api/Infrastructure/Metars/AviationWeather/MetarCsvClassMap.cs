using CsvHelper.Configuration;

namespace Metars.Api.Infrastructure.Metars.AviationWeather;

public sealed class MetarCsvClassMap : ClassMap<AviationWeatherCsvMetar>
{
    public MetarCsvClassMap()
    {
        Map(m => m.Text).Name("raw_text");
        Map(m => m.StationIcao).Name("station_id");
        Map(m => m.ObservationTime).Name("observation_time");
        Map(m => m.TempC).Name("temp_c");
        Map(m => m.DewpointC).Name("dewpoint_c");
        Map(m => m.WindDirectionDegrees).Name("wind_dir_degrees").Default(0);
        Map(m => m.WindSpeedKnots).Name("wind_speed_kt").Default(0);
        Map(m => m.WindGustKnots).Name("wind_gust_kt").Default(0);
        Map(m => m.Visibility).Name("visibility_statute_mi");
        Map(m => m.AltimeterInHg).Name("altim_in_hg");
        Map(m => m.FlightCategory).Name("flight_category");

        Map(m => m.SkyCoverLayer1).Name("sky_cover").NameIndex(0).Default(null);
        Map(m => m.CloudBaseFeetAglLayer1).Name("cloud_base_ft_agl").NameIndex(0);
        Map(m => m.SkyCoverLayer2).Name("sky_cover").NameIndex(1).Default(null);
        Map(m => m.CloudBaseFeetAglLayer2).Name("cloud_base_ft_agl").NameIndex(1);
        Map(m => m.SkyCoverLayer3).Name("sky_cover").NameIndex(2).Default(null);
        Map(m => m.CloudBaseFeetAglLayer3).Name("cloud_base_ft_agl").NameIndex(2);
        Map(m => m.SkyCoverLayer4).Name("sky_cover").NameIndex(3).Default(null);
        Map(m => m.CloudBaseFeetAglLayer4).Name("cloud_base_ft_agl").NameIndex(3);
    }
}