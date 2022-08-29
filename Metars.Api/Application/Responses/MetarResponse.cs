namespace Metars.Api.Application.Responses;

public class MetarResponse
{
    public string StationIcao { get; set; } = null!;
    public string Text { get; set; } = null!;
    public double WindDirectionDegrees { get; init; }
    public double WindSpeedKnots { get; init; }
    public double WindGustKnots { get; init; }
    public double? Visibility { get; init; }
    public double? AltimeterInHg { get; init; }
    public string? FlightCategory { get; init; }
    public double? TempC { get; init; }
    public double? DewpointC { get; init; }
    public List<string> SkyCover { get; set; } = new ();
}