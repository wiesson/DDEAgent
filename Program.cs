using System;
using System.Collections.Generic;
using System.Text;

namespace DDEAgent {
    class Program {
        static void Main(string[] args) {
            // todo: move to Configuration.cs
            string serverAddress = "192.168.10.1";
            int serverPort = 12345;
            string clientId = "1-1-1";
            string eventValue = "11";

            // read config.xml
            // Configuration.LoadFile();
            string eventTime = DateTime.Now.ToString("yyMMddHHmmssfff");
            
            // todo: implement DDE Event Listener
            string eventEventDemo = "/Channel/State/actTNumber";

            // translate event
            string eventEvent = Event.Translator(eventEventDemo);

            Network.SendMessage(serverAddress, serverPort, clientId, eventTime, eventEvent, eventValue);
            
            // todo: some debug below
            // Console.WriteLine(eventTime);
            // Console.WriteLine(eventEvent);
            // string test = Console.ReadLine();            
        }
    }
}