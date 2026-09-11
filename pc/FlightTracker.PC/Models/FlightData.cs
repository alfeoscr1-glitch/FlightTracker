namespace FlightTracker.PC.Models;

public class FlightData
{
    public string Callsign { get; set; } = "";
    public string AircraftType { get; set; } = "";
    public string Registration { get; set; } = "";

    public double Latitude { get; set; }
    public double Longitude { get; set; }

    public double Altitude { get; set; }
    public double GroundSpeed { get; set; }
    public double Heading { get; set; }
    public double VerticalSpeed { get; set; }

    public string Squawk { get; set; } = "";

    public long Timestamp { get; set; }
}
