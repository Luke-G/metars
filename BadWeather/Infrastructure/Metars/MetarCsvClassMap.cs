using BadWeather.Domain.Models;
using CsvHelper.Configuration;

namespace BadWeather.Infrastructure.Metars;

public sealed class MetarCsvClassMap : ClassMap<Metar>
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

        Map(m => m.SkyCover).Name("sky_cover");
        Map(m => m.CloudBaseFeetAgl).Name("cloud_base_ft_agl");

        Map(m => m.FlightCategory).Name("flight_category");
    }
}