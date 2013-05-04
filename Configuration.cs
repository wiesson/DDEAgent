using System;
using System.Xml;
using System.Collections.Generic;

namespace DDEAgent {
    class Configuration {
        private string _serverAddress = "";
        public string serverAddress {
            get { return _serverAddress; }
            set { _serverAddress = value; }
        }
        private int _serverPort;
        public int serverPort {
            get { return _serverPort; }
            set { _serverPort = value; }
        }
        private string _clientId;
        public string clientId {
            get { return _clientId; }
            set { _clientId = value; }
        }
        
        public void loadFile(string path) {
            try {
                XmlDocument doc = new XmlDocument();
                doc.Load(path);

                serverAddress = doc.SelectSingleNode("descendant::*[name(.) ='Server']").InnerText;
                serverPort  = Convert.ToInt32(doc.SelectSingleNode("descendant::*[name(.) ='Port']").InnerText);
                clientId = doc.SelectSingleNode("descendant::*[name(.) ='Id']").InnerText;

                XmlNodeList nodeList = doc.GetElementsByTagName("DataItem");
                foreach (XmlNode item in nodeList) {
                    Events.ListAdd(item.Attributes.Item(0).Value, item.Attributes.Item(1).Value);
                }

            } catch (Exception ex) {
                Console.WriteLine("Error in loadFile: "+ ex);            
            }
        }
    }
}
