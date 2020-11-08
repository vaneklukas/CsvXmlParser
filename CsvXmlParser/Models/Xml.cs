using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace CsvXmlParser.Models
{
    class Xml
    {
        public void write(string[] data)
        {
           string path = ConfigurationManager.AppSettings.Get("xml");

            
            if (!File.Exists(path))
            {
                XDocument dokument = new XDocument(
             new XDeclaration("1.0", "UTF-8", null),
             new XElement("Production",
             new XElement("Items",
             new XElement("Item",
             new XAttribute("type", data[0]),
             new XAttribute("date", data[1]),
             new XElement("Partner", data[2]),
             new XElement("Width", data[3]),
             new XElement("Height",data[4]),
             new XElement("Amount", data[6],
             new XAttribute("unit", data[5]))
             ))));
                dokument.Save(path);
            }
            else
            {
                //todo: add new route to config file
                var doc = XDocument.Load(path);
                XElement newRecord = doc.Element("Production").Element("Items");

                var newElement =
                                new XElement("Item",
                                new XAttribute("type", data[0]),
                                new XAttribute("date", data[1]),
                                new XElement("Partner", data[2]),
                                new XElement("Width", data[3]),
                                new XElement("Height", data[4]),
                                new XElement("Amount", data[6],
                                new XAttribute("unit", data[5])));

                doc.Element("Production").Element("Items").Add(newElement);
                doc.Save(path);

            }

            

        }
    }
}
