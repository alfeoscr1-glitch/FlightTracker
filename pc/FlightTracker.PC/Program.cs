using FlightTracker.PC.Services;

Console.WriteLine("FlightTracker PC Bridge");
Console.WriteLine("=======================");
Console.WriteLine();

var fsuipc = new FSUIPCService();

Console.WriteLine("Connecting to FSUIPC7...");

if (fsuipc.Connect())
{
    Console.WriteLine("SUCCESS: Connected to FSUIPC7.");
    Console.WriteLine();
    Console.WriteLine("FlightTracker bridge is ready.");
}
else
{
    Console.WriteLine("FAILED: Could not connect to FSUIPC7.");
    Console.WriteLine();
    Console.WriteLine("Make sure FSUIPC7 and MSFS 2024 are running.");
}

Console.WriteLine();
Console.WriteLine("Press ENTER to exit.");
Console.ReadLine();

fsuipc.Disconnect();
