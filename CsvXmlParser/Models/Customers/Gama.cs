using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CsvXmlParser.Models.Customers
{
    class Gama:DefaultCustomerRules
    {
        public static void check(string[] data)
        {
            bool validation = validate(data);
            if (validation == false)
            {
                writeError(data);
            }
            else
            {
                string[] parsedcsv = parseData(data);
                writexml(parsedcsv);
            }
        }

        private static string[] parseData(string[] data)
        {
            string[] xmlData = new string[7];

            //customer
            xmlData[2] = data[1];

            //date
            string[] dateString = data[0].Split('.');

            xmlData[1] = dateString[2] + '-' + dateString[1] + '-' + dateString[0];

            //widht height
            string s = data[2].Substring(1);

            string ss = s.TrimStart('0');
            string[] gg = ss.Split('A');


            //widht
            xmlData[3] = gg[0].Substring(gg[0].Length - 7).TrimStart('0');
            //height
            xmlData[4] = gg[0].Substring(0, gg[0].Length - 7);

            //type and unit
            string[] hh = gg[1].Split('|');
            char x = hh[0].Last();

            switch (x)
            {
                case 'p':
                    xmlData[5] = "ks";
                    break;
                case 'w':
                    xmlData[5] = "kg";
                    break;
                case 's':
                    xmlData[5] = "m2";
                    break;
            }

            string type = hh[1].Substring(0, 2);
            switch (type)
            {
                case "ET":
                    xmlData[0] = "ETIKETA";
                    break;
                case "SL":
                    xmlData[0] = "SLEEVE";
                    break;
                case "TU":
                    xmlData[0] = "TUBA";
                    break;
                case "OB":
                    xmlData[0] = "OBAL";
                    break;
            }
            //amount
            xmlData[6] = hh[0].Remove(hh[0].Length - 1);

            return xmlData;
        }

        private static bool validate(string[] data)
        {
            bool result = false;

            string[] x = data[2].Split('|');

            int eanL = x[0].Length;
            int val;
            string value = data[3].Substring(2);
            bool valid = Int32.TryParse(value, out val);

            if (eanL==val)
            {
                result = true;
            }

            return result;
        }
    }
}
