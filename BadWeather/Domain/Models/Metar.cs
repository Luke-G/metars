namespace BadWeather.Domain.Models;

public class Metar
{
    public Guid Id { get; set; }

    public string Text { get; init; } = null!;
    public string StationIcao { get; init; } = null!;
    public string? ObservationTime { get; set; }
    public double WindDirectionDegrees { get; init; }
    public double WindSpeedKnots { get; init; }
    public double WindGustKnots { get; init; }
    public double? Visibility { get; init; }
    public double? AltimeterInHg { get; init; }
    public string? FlightCategory { get; init; }
    public double? TempC { get; init; }
    public double? DewpointC { get; init; }
    
    public int? CloudBaseFeetAglLayer1 { get; init; }
    public string? SkyCoverLayer1 { get; init; }
    
    public int? CloudBaseFeetAglLayer2 { get; init; }
    public string? SkyCoverLayer2 { get; init; }
    
    public int? CloudBaseFeetAglLayer3 { get; init; }
    public string? SkyCoverLayer3 { get; init; }
    
    public int? CloudBaseFeetAglLayer4 { get; init; }
    public string? SkyCoverLayer4 { get; init; }
}