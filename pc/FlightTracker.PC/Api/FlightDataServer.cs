using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using FlightTracker.PC.Models;

namespace FlightTracker.PC.Api;

public class FlightDataServer : IDisposable
{
    private readonly UdpClient _udpClient;
    private readonly IPEndPoint _broadcastEndpoint;

    public FlightDataServer(int udpPort = 49000)
    {
        _udpClient = new UdpClient
        {
            EnableBroadcast = true
        };

        _broadcastEndpoint = new IPEndPoint(
            IPAddress.Broadcast,
            udpPort
        );
    }

    public async Task SendAsync(FlightData flightData)
    {
        string json = JsonSerializer.Serialize(flightData);

        byte[] data = Encoding.UTF8.GetBytes(json);

        await _udpClient.SendAsync(
            data,
            data.Length,
            _broadcastEndpoint
        );
    }

    public void Dispose()
    {
        _udpClient.Dispose();
    }
}
