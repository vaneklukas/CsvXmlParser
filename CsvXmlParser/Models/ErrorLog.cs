using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvXmlParser.Models
{
    class ErrorLog
    {
        string path = ConfigurationManager.AppSettings.Get("error");

        public void WriteUnknownCustomer( string customer)
        {
            using (StreamWriter writer = new StreamWriter(path,true))
            {
                writer.WriteLine(DateTime.Now+" - Zákazník {0} nebyl nalezen", customer);
            }
        }
        public void writeValidationError(string[]data)
        {
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(DateTime.Now + " - Pro partnera {0} a EAN {1} nesouhlasi" +
                    " kontrolni sekvence", data[1],data[2]);
            }
        }
    }
}
