namespace BadWeather.Domain.Models;

public class Metar
{
    public string Text { get; init; } = null!;

    public string StationIcao { get; init; } = null!;
    
    public string? ObservationTime { get; set; }

    public double WindDirectionDegrees { get; init; }

    public double WindSpeedKnots { get; init; }

    public double WindGustKnots { get; init; }
    
    public double? Visibility { get; init; }
    
    public double? AltimeterInHg { get; init; }
    
    public string? FlightCategory { get; init; }
    
    public int? CloudBaseFeetAgl { get; init; }
    
    public string? SkyCover { get; init; }
    
    public double? TempC { get; init; }
    
    public double? DewpointC { get; init; }
}