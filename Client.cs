using System;
using System.Text;
using NDde.Client;

namespace DDEAgent {
    public sealed class Client {
        public static void ddeAgent() {
            string myApp = "ncdde";
            string myTopic = "machineswitch";
            // Wait for the user to press ENTER before proceding.
            try {
                // Create a client that connects to 'myapp|mytopic'. 
                using (DdeClient client = new DdeClient(myApp, myTopic)) {
                    client.Disconnected += OnDisconnected;

                    // Connect to the server.  It must be running or an exception will be thrown.
                    client.Connect();
                    // Advise Loop

                    /* foreach() {
                    } */

                    client.StartAdvise("/Channel/ProgramInfo/actLineNumber", 1, true, 60000);
                    /* 
                    client.StartAdvise("/Channel/State/actTNumber", 1, true, 60000);
                    client.StartAdvise("/Channel/Spindle/cmdSpeed[1]", 1, true, 60000);
                    client.StartAdvise("/Channel/Spindle/speedOvr[1]", 1, true, 60000);
                    client.StartAdvise("/Channel/Spindle/driveLoad[1]", 1, true, 60000);
                    client.StartAdvise("/Channel/State/actFeedRateIpo", 1, true, 60000);
                    client.StartAdvise("/Channel/State/feedRateIpoOvr", 1, true, 60000);
                    client.StartAdvise("/Channel/MachineAxis/actToolBasePos[1]", 1, true, 60000);
                    client.StartAdvise("/Channel/MachineAxis/actToolBasePos[2]", 1, true, 60000);
                    client.StartAdvise("/Channel/MachineAxis/actToolBasePos[3]", 1, true, 60000);
                    client.StartAdvise("/Channel/ProgramInfo/actLineNumber", 1, true, 60000);
                    client.StartAdvise("/Channel/State/progStatus", 1, true, 60000); // 1 = interrupted 2 = stopped 3 = in progress 4 = waiting 5 = aborted
                    client.StartAdvise("/Channel/ProgramPointer/actInvocCount", 1, true, 60000); // "0: program stop, 1: program start"
                    client.StartAdvise("/Channel/ProgramInfo/progName", 1, true, 60000);
                    client.StartAdvise("/Channel/ProgramInfo/singleBlock[2]", 1, true, 60000);
                    client.StartAdvise("/Channel/State/chanAlarm", 1, true, 60000);
                    client.StartAdvise("/Bag/State/opMode", 1, true, 60000);
                    */
                    client.Advise += OnAdvise;

                    // Wait for the user to press ENTER before proceding.
                    Console.WriteLine("Press ENTER to quit...");
                    Console.ReadLine();
                }
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
                Console.WriteLine("Press ENTER to quit...");
                Console.ReadLine();
            }
        }

        private static void OnExecuteComplete(IAsyncResult ar) {
            try {
                DdeClient client = (DdeClient)ar.AsyncState;
                client.EndExecute(ar);
                Console.WriteLine("OnExecuteComplete");
            } catch (Exception e) {
                Console.WriteLine("OnExecuteComplete: " + e.Message);
            }
        }

        private static void OnPokeComplete(IAsyncResult ar) {
            try {
                DdeClient client = (DdeClient)ar.AsyncState;
                client.EndPoke(ar);
                Console.WriteLine("OnPokeComplete");
            } catch (Exception e) {
                Console.WriteLine("OnPokeComplete: " + e.Message);
            }
        }

        private static void OnRequestComplete(IAsyncResult ar) {
            try {
                DdeClient client = (DdeClient)ar.AsyncState;
                byte[] data = client.EndRequest(ar);
                Console.WriteLine("OnRequestComplete: " + Encoding.ASCII.GetString(data));
            } catch (Exception e) {
                Console.WriteLine("OnRequestComplete: " + e.Message);
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
            string eventTime = DateTime.Now.ToString("yyMMddHHmmssfff");
            string eventValue = args.Text.Replace(Convert.ToChar(0x0).ToString(), ""); // avoid 0x0 .. 

            string xmlMessage = Events.createMessage(Configuration.clientId, eventTime, args.Item, eventValue);
            Network.sendMessage(Configuration.serverAddress, Configuration.serverPort, xmlMessage);
        }

        private static void OnDisconnected(object sender, DdeDisconnectedEventArgs args) {
            Console.WriteLine(
                "OnDisconnected: " +
                "IsServerInitiated=" + args.IsServerInitiated.ToString() + " " +
                "IsDisposed=" + args.IsDisposed.ToString());
        }

    } // class

} // namespace
