using System;
using FlightTracker.PC.Models;
using FSUIPC;
using FSUIPC.FSUIPCExceptions;

namespace FlightTracker.PC.Services;

public class FSUIPCService
{
    private bool _connected;

    public bool IsConnected => _connected;

    public bool Connect()
    {
        try
        {
            FSUIPCConnection.Open();

            _connected = true;

            Console.WriteLine("Connected to FSUIPC7.");

            return true;
        }
        catch (Exception ex)
        {
            _connected = false;

            Console.WriteLine($"Could not connect to FSUIPC7: {ex.Message}");

            return false;
        }
    }

    public void Disconnect()
    {
        if (!_connected)
            return;

        try
        {
            FSUIPCConnection.Close();
        }
        catch
        {
            // Ignore disconnect errors.
        }

        _connected = false;

        Console.WriteLine("Disconnected from FSUIPC7.");
    }

    public FlightData? ReadFlightData()
    {
        if (!_connected)
            return null;

        try
        {
            // Telemetry offsets will be added here next.
            // We deliberately do not read simulator data yet.

            return new FlightData
            {
                Timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()
            };
        }
        catch (FSUIPCException ex)
        {
            Console.WriteLine($"FSUIPC read error: {ex.Message}");

            _connected = false;

            return null;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Flight data error: {ex.Message}");

            return null;
        }
    }
}
