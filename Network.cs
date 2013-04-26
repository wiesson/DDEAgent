using System; // For String, Int32, Console, ArgumentException
using System.Text; // For Encoding
using System.Net.Sockets; // For TcpClient, NetworkStream, SocketException
using System.Net;
using System.Collections.Generic;
using System.IO;

class Network {
    public static void SendMessage(string serverAddress, int serverPort, string machineEvent, string datetime) {

        IPAddress ipAddress = IPAddress.Parse(serverAddress);
      

        string clientEvent = machineEvent;
        string clientTime = datetime;
        string clientId = "1-1-1";
        string clientValue = "11";

        string message = "<?xml  version=\"1.0\"  encoding=\"utf-8\"  ?><message><id>"
               + clientId + "</id><datetime>"
               + clientTime + "</datetime><event>"
               + clientEvent + "</event><value>"
               + clientValue + "</value></message>";

        TcpClient client = new TcpClient(serverAddress, serverPort);
        try {
            Stream s = client.GetStream();
            StreamWriter sw = new StreamWriter(s);
            sw.AutoFlush = true;

            sw.WriteLine(message);

            s.Close();
        } catch (Exception e) {
            Console.WriteLine("Error: " + e.StackTrace);
        } finally {
            client.Close();
        }
    }
}