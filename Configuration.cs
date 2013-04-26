using System;
using System.Xml;

namespace DDEAgent {
    class Configuration {
        public static void LoadFile() {
            // todo: implement config XML
            // string machineId, serverAddress, serverPort;
            
            XmlDocument doc = new XmlDocument();
            doc.Load("config.xml");

            Console.Write(doc.DocumentElement.GetAttribute("machineId"));
            // get DataItems 
            XmlNodeList dataItems = doc.GetElementsByTagName("DataItem");
            // get ConfigItems
            XmlNodeList configList = doc.GetElementsByTagName("ConfigItem");
            for (int i = 0; i < configList.Count; i++) {
                Console.WriteLine(configList[i].InnerXml + "\n");
            }

            /* public static void CreateXML() {

            // Create the XmlDocument.
            XmlDocument doc = new XmlDocument();
            // doc.LoadXml("<item><name>wrench</name></item>");
            doc.Load("c:/Users/arnewiese/Desktop/DDEAgent/config.xml");
            /* 
            XmlNodeList elemList = doc.GetElementsByTagName("DataItems");
          
            for (int i = 0; i < elemList.Count; i++) {
                Console.WriteLine(elemList[i].InnerXml + "\n");
            } */
            /*
            doc.GetElementsByTagName("global");
            foreach (XmlElement elmt in infolist) {
                XmlAttribute attr = elmt.Attributes["key"];
                if (attr.Value == "ProgramDir") {
                    programdir = elmt.Attributes["value"].Value;
                }
            } 

            
            // Add a price element.
            XmlElement newElem = doc.CreateElement("price");
            newElem.InnerText = "10.95";
            doc.DocumentElement.AppendChild(newElem);

            // Save the document to a file and auto-indent the output.
            XmlTextWriter writer = new XmlTextWriter("data.xml", null);
            writer.Formatting = Formatting.Indented;
            doc.Save(writer);

            System.Console.WriteLine("XML written.");
        } */
        }
    }
}
