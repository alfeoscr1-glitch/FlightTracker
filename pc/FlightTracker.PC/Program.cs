using FlightTracker.PC.Api;
using FlightTracker.PC.Services;

Console.WriteLine("FlightTracker PC Bridge");
Console.WriteLine("=======================");
Console.WriteLine();

var fsuipc = new FSUIPCService();
using var server = new FlightDataServer(49000);

Console.WriteLine("Connecting to FSUIPC7...");

if (!fsuipc.Connect())
{
    Console.WriteLine("FAILED: Could not connect to FSUIPC7.");
    Console.WriteLine();
    Console.WriteLine("Make sure FSUIPC7 and MSFS 2024 are running.");
    Console.WriteLine();
    Console.WriteLine("Press ENTER to exit.");
    Console.ReadLine();
    return;
}

Console.WriteLine("SUCCESS: Connected to FSUIPC7.");
Console.WriteLine("FlightTracker bridge is running.");
Console.WriteLine("UDP server: port 49000");
Console.WriteLine();

try
{
    while (true)
    {
        var flightData = fsuipc.ReadFlightData();

        if (flightData != null)
        {
            await server.SendAsync(flightData);
            Console.WriteLine(
                $"Telemetry sent: {flightData.Timestamp}"
            );
        }

        await Task.Delay(500);
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Bridge error: {ex.Message}");
}
finally
{
    fsuipc.Disconnect();
}
