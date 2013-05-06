using System;
using System.Collections;
using System.Text;
using NDde.Client;

namespace DDEAgent {
    class DDEAgent {
         public static void Main(string[] args) {
            XMLConfig.loadFile();            

            // Wait for the user to press ENTER before proceding.
            Console.WriteLine("starting DDEAgent");
            Client.ddeAgent();

             /*
            try {
                Network.sendMessage(myMachine.serverAddress, myMachine.serverPort, xmlMessage);
                Console.WriteLine(xmlMessage);
            } catch (Exception e) {
                // Console.WriteLine(e.ToString());
                Console.WriteLine("Network error, unable to find the server.\nPress ENTER to continue... "+e);
                Console.ReadLine();
                // myQ.Enqueue(xmlMessage);
            } */

            // Wait for the user to press ENTER before proceding.
            Console.WriteLine("Press ENTER to quit...");
            Console.ReadLine();           
        }

    }
}