using System; // For String, Int32, Console, ArgumentException
using System.Text; // For Encoding
using System.Net.Sockets; // For TcpClient, NetworkStream, SocketException
using System.Net;
using System.Collections.Generic;
using System.IO;

namespace DDEAgent {
    class Network {
        public static string TcpClient(string var, string datetime) {

            string machineEvent = var;
            string machineTime = datetime;
            string machineId = "1-1-1";
            string machineValue = "11";

            try {
                string message = "<?xml version=\"1.0\" encoding=\"utf-8\" ?><message><id>" 
                    + machineId + "</id><datetime>" 
                    + datetime + "</datetime><event>" 
                    + var + "</event><value>"
                    + machineValue + "</value></message>";

                TcpClient client = new TcpClient();

                IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse("192.168.10.1"), 12345);

                client.Connect(serverEndPoint);

                NetworkStream clientStream = client.GetStream();

                Console.WriteLine(message);

                ASCIIEncoding encoder = new ASCIIEncoding();
                byte[] buffer = encoder.GetBytes(message);
                clientStream.Write(buffer, 0, buffer.Length);
                clientStream.Flush();
            }
 
            catch (Exception e) {
                Console.WriteLine("Error..... " + e.StackTrace);
            }
        return "null";
        }
    }
}