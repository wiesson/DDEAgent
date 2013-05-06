using System;
using System.Xml;
using System.Collections.Generic;
using System.IO;

namespace DDEAgent {
    class XMLConfig {
        public static string clientId { get; set; }
        public static string serverAddress { get; set; }
        public static int serverPort { get; set; }
        
        public static void loadFile() {
            string path = "config.xml";
            
            // todo: for debug
            if(!File.Exists(path)){
                path = "c:/Users/arnewiese/Desktop/DDEAgent/DDEAgent/config.xml";    
            }
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
        static public void CheckRelativeFilePath() {
            //This folder path is %project directory%/bin/debug/test/img.bmp
            bool exists = File.Exists("test/img.bmp");
        }
    }
}
