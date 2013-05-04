using System;               // For String, Int32, Console, ArgumentException
using System.Text;          // For Encoding
using System.Net;
using System.Net.Sockets;   // For TcpClient, NetworkStream, SocketException
using System.IO;

class Network {
    public void sendMessage(string serverAddress, int serverPort, string xmlMessage) {

        IPAddress ipAddress = IPAddress.Parse(serverAddress);
        TcpClient client = new TcpClient(serverAddress, serverPort);

        try {
            Stream s = client.GetStream();
            StreamWriter sw = new StreamWriter(s);
            sw.AutoFlush = true;
            sw.WriteLine(xmlMessage);
            s.Close();
        } catch (Exception e) {
            Console.WriteLine("Error: " + e.StackTrace);

        } finally {
            client.Close();
        }
    }
}