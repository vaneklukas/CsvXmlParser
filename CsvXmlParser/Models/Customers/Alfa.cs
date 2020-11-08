using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvXmlParser.Models.Customers
{
    class Alfa : DefaultCustomerRules
    {
        //hello
        // tag:#alfa
        public static void check(string[]data)
        {
            bool validation=validate(data);
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
            // customer
            xmlData[2] = data[1];

            //product type
            char t = data[2].First();
            switch (t)
            {
                case 'E':
                    xmlData[0] = "ETIKETA";
                    break;
                case 'S':
                    xmlData[0] = "SLEEVE";
                    break;
                case 'T':
                    xmlData[0] = "TUBA";
                    break;
                case 'O':
                    xmlData[0] = "OBAL";
                    break;
            }

            //date
            string[] dateString = data[0].Split('.');

            xmlData[1] = dateString[2]+'-'+dateString[1]+'-'+dateString[0];

            //height and widht

            string ad = data[2].Substring(3);

            string[] splitter = { "0W0" };

            string[] parsed = ad.Split(splitter, StringSplitOptions.None);


            //widht
            xmlData[3] = parsed[0];

            //height
            xmlData[4] = parsed[1];

            //amount
            xmlData[6]= parsed[2].Substring(0,parsed[2].Length - 2);

            //unit
            xmlData[5]= parsed[2].Substring(parsed[2].Length - 2);
           
            return xmlData;
        }

        private static bool validate(string[] data)
        {
            bool result=false;
            int sum=0;
            char[] ean = data[2].Remove(data[2].Length-2).ToCharArray();
            foreach (var singlechar in ean)
            {
                if (Char.IsNumber(singlechar))
                {
                    sum += Convert.ToInt32(singlechar.ToString());
                }
            }

            int a;

            bool valid =Int32.TryParse(data[3], out a);

            if (!valid)
            {
                result= false;
              
            }
            else
            {
                int modulo = sum % 17;
                if (modulo==a)
                {
                    result = true;
                    
                }
            }
            return result;
        }

        
    }
}
