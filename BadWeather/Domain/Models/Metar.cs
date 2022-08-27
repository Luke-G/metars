namespace BadWeather.Domain.Models;

public class Metar
{
    public string? Text { get; set; }
    
    public string? StationIcao { get; set; }
    
    public string? ObservationTime { get; set; }

    public double WindDirectionDegrees { get; set; }
    
    public double WindSpeedKnots { get; set; }
    
    public double WindGustKnots { get; set; }
    
    public double Visibility { get; set; }
    
    public double AltimeterInHg { get; set; }
    
    public string? FlightCategory { get; set; }
}