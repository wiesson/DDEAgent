using System;
using System.Collections;
using System.Text;
using NDde.Client;

namespace DDEAgent {
    class DDEAgent {
         public static void Main(string[] args) {
            // load config from XML file
            XMLConfig.loadFile();
            Console.WriteLine("starting DDEAgent !!!!");
			Agent ();
        }
        
        public static void Agent() {
            // Create a client that connects to 'myapp|machineswitch'
            string myApp = "ncdde";
            string myTopic = "machineswitch";

			DdeClient client = new DdeClient (myApp, myTopic);
            try {
				client.Disconnected += OnDisconnected; 

				// Advise Loop
				client.Connect();
				for(int i = 0; i < Events.list.Count; i++) {
					client.StartAdvise(Events.list[i].foreignEvent,1,true,60000);
				}

				client.Advise += OnAdvise;

				// Console.WriteLine("Press ENTER to quit...");
				Console.ReadLine();
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
                // Console.WriteLine("Press ENTER to quit...");
                Console.ReadLine();
			} finally {
			}
        }
       
        private static void OnStartAdviseComplete(IAsyncResult ar) {
            try {
                DdeClient client = (DdeClient)ar.AsyncState;
                client.EndStartAdvise(ar);
                Console.WriteLine("OnStartAdviseComplete");
            } catch (Exception e) {
                Console.WriteLine("OnStartAdviseComplete: " + e.Message);
            }
        }

        private static void OnStopAdviseComplete(IAsyncResult ar) {
            try {
                DdeClient client = (DdeClient)ar.AsyncState;
                client.EndStopAdvise(ar);
                Console.WriteLine("OnStopAdviseComplete");
            } catch (Exception e) {
                Console.WriteLine("OnStopAdviseComplete: " + e.Message);
            }
        }

        private static void OnAdvise(object sender, DdeAdviseEventArgs args) {
            Console.WriteLine(args.Item + ": " + args.Text);
            string eventTime = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fff+02:00");
            string eventValue = args.Text.Replace(Convert.ToChar(0x0).ToString(), ""); // avoid 0x0 error !! 

            string xmlMessage = Events.createMessage(XMLConfig.clientId, eventTime, args.Item, eventValue);
            try {
                Network.sendMessage(XMLConfig.serverAddress, XMLConfig.serverPort, xmlMessage);
            } catch (Exception e) {
                Console.WriteLine("Network error, unable to connect to server! ");
            } 
        }

        private static void OnDisconnected(object sender, DdeDisconnectedEventArgs args) {
            Console.WriteLine(
                "OnDisconnected: " +
                "IsServerInitiated=" + args.IsServerInitiated.ToString() + " " +
                "IsDisposed=" + args.IsDisposed.ToString());
        }
    }
} 