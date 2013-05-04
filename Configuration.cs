using System;
using System.Xml;
using System.Collections.Generic;

namespace DDEAgent {
    class Configuration {
        public string clientId { get; set; }
        public string serverAddress { get; set; }
        public int serverPort { get; set; }
        
        public void loadFile(string path) {
            try {
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                
                // find ConfigItems
                XmlNodeList configList = doc.GetElementsByTagName("ConfigItem");
                for(int i = 0; i < configList.Count; i++) {
                    if (configList.Item(i).Attributes.Item(0).Value.Equals("id")) {
                        clientId = configList.Item(i).InnerText;
                    }
                    if (configList.Item(i).Attributes.Item(0).Value.Equals("server")) {
                        serverAddress = configList.Item(i).InnerText;
                    }
                    if (configList.Item(i).Attributes.Item(0).Value.Equals("port")) {
                        serverPort = Convert.ToInt32(configList.Item(i).InnerText);
                    }
                }

                // find Attributes
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
