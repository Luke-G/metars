using CsvHelper.Configuration.Attributes;

namespace BadWeather.Domain.Models;

public class AviationWeatherCsvMetar
{
    [Name("raw_text")]
    public string? RawText { get; set; }
    
    [Name("station_id")]
    public string? StationId { get; set; }
    
    [Name("observation_time")]
    public string? ObservationTime { get; set; }
    
    [Name("latitude")]
    public double? Latitude { get; set; }
    
    [Name("longitude")]
    public double? Longitude { get; set; }
    
    [Name("temp_c")]
    public double? TempC { get; set; }
    
    [Name("dewpoint_c")]
    public double? DewpointC { get; set; }
    
    [Name("wind_dir_degrees")]
    public double? WindDirDegrees { get; set; }
    
    [Name("wind_speed_kt")]
    public double? WindSpeedKt { get; set; }
    
    [Name("wind_gust_kt")]
    public double? WindGustKt { get; set; }
    
    [Name("visibility_statute_mi")]
    public double? VisibilityStatuteMi { get; set; }
    
    [Name("altim_in_hg")]
    public double? AltimInHg { get; set; }
    
    [Name("sea_level_pressure_mb")]
    public double? SeaLevelPressureMb { get; set; }

    [Name("wx_string")]
    public string? WxString { get; set; }
    
    // [Name("sky_condition")]
    // public string SkyCondition { get; set; }
    
    [Name("flight_category")]
    public string? FlightCategory { get; set; }

    [Name("three_hr_pressure_tendency_mb")]
    public double? ThreeHrPressureTendencyMb { get; set; }

    [Name("snow_in")]
    public double? SnowIn { get; set; }

    [Name("vert_vis_ft")]
    public double? VertVisFt { get; set; }

    [Name("metar_type")]
    public string? MetarType { get; set; }

    [Name("elevation_m")]
    public double? ElevationM { get; set; }
}