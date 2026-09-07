using GoveeAmbilight.Command_Packages;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Reflection.Emit;
using System.Text;
using System.Text.Json;

namespace GoveeAmbilight
{
    public class GoveePackageSender
    {
        private static readonly string _multicastIp = "239.255.255.250";
        private static readonly int _recvPort = 4002;
        private static readonly int _sendPort = 4001;

        public async Task<TResponse?> SendAsync<TRequest, TResponse>(
            TRequest request,
            int timeoutMs = 500)
            where TRequest : IGoveeRequestPackage
            where TResponse : IGoveeResponsePackage
        {
            using var sendClient = new UdpClient(_sendPort);
            using var recvClient = new UdpClient(_recvPort);

            recvClient.Client.ReceiveTimeout = timeoutMs;

            var endpoint = new IPEndPoint(IPAddress.Parse(_multicastIp), _sendPort);
            var bytes = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(request));

            try
            {
                await sendClient.SendAsync(bytes, bytes.Length, endpoint);

                var result = recvClient.Receive(ref endpoint);
                var json = Encoding.UTF8.GetString(result);

                return JsonSerializer.Deserialize<TResponse>(json);
            }
            catch (SocketException)
            {
                return default;
            }
        }

        /** Deprecated code

        //public static async Task<string> SendPackage(string json)
        //{
        //    using var receiveClient = new UdpClient(_recvPort);
        //    receiveClient.Client.ReceiveTimeout = _timeout;

        //    using var sendClient = new UdpClient(_sendPort);
        //    sendClient.Client.SendTimeout = _timeout;

        //    var remoteEndpoint = new IPEndPoint(
        //        IPAddress.Parse(_multicastIp),
        //        _sendPort
        //    );

        //    byte[] data = Encoding.UTF8.GetBytes(json);

        //    try
        //    {
        //        sendClient.Send(data, data.Length, remoteEndpoint);
        //    }
        //    catch (SocketException)
        //    {
        //        Console.WriteLine("Send timed out!");
        //        return "";
        //    }

        //    string recvPackage = await ReceivePackage(receiveClient);
        //    return recvPackage;
        //}

        //private static async Task<string> ReceivePackage(UdpClient recvClient)
        //{
        //    string response = "";

        //    try
        //    {
        //        IPEndPoint? from = null;
        //        byte[] received = recvClient.Receive(ref from);
        //        response = Encoding.UTF8.GetString(received);
        //    }
        //    catch (SocketException)
        //    {
        //        Console.WriteLine("Connection timed out!");
        //    }

        //    return response;
        //}

        //public static byte[] ReceivePackage()
        //{

        //}
         */
    }
}
