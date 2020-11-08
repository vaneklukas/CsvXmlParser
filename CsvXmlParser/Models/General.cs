using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CsvXmlParser.Models
{
    class General
    {
        public string run (string path)
        {
            //read csv
            string[] lines = File.ReadAllLines(path);

            //validate each line
            foreach (var line in lines)
            {
                if (!line.StartsWith("Datum"))
                {
                    string[] data = line.Split(';');

                    Type type = Type.GetType("CsvXmlParser.Models.Customers." + data[1]);
                    if (type==null)
                    {
                        ErrorLog errorLog = new ErrorLog();
                        errorLog.WriteUnknownCustomer(data[1]);
                    }
                    else
                    {
                        object[] obj = new object[] { data };
                        MethodInfo method = type.GetMethod("check");
                        method.Invoke(null,obj);
                    }
                }
            }
            return "zpracovano";
        }
    }
}
