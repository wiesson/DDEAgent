using System;
using System.Collections;
using System.Text;

namespace DDEAgent {
    class Program {
         static void Main(string[] args) {
            // todo: move to Configuration.cs and load XML file
            
            Configuration myMachine = new Configuration();
            Network myNetwork = new Network();

            myMachine.loadFile("c:/Users/arnewiese/Desktop/DDEAgent/config.xml");
            // Events.ListGet();
            
            // get DateTime    
            string eventTime = DateTime.Now.ToString("yyMMddHHmmssfff");
            
            // todo: implement DDE Event Listener
            string eventEventDemo = "/Channel/State/actTNumber";
            string eventValue = "11";

            // translate event
            string eventEvent = Events.searchEvent(eventEventDemo);
            
             // create XML string
            string xmlMessage = Events.createMessage(myMachine.clientId, eventTime, eventEvent, eventValue);
            
            Queue myQ = new Queue();

            try {
                myNetwork.SendMessage(myMachine.serverAddress, myMachine.serverPort, xmlMessage);
            } catch (Exception ex) {
                Console.WriteLine(ex);
                myQ.Enqueue(xmlMessage);
            }
             
            // todo: some debug below
            Console.WriteLine(xmlMessage);
            string test = Console.ReadLine();            
        }
    }
}