using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvXmlParser.Models.Customers
{
    class Beta:DefaultCustomerRules
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


            //amount and unit

            string amount=data[2].Substring(0,15);

            string[] splitter = { "ks","m2","kg" };

            string[] ss = amount.Split(splitter, StringSplitOptions.None);

            int i = ss[0].Length;
            string aa = amount.Substring(i , 2);


            //amount
            xmlData[6] = aa;
            //unit
            xmlData[5] = ss[0];

            //width and height
            string wh = data[2].Substring(15);

            char[] x = { 'x', 't' };

            string[] xy = wh.Split(x);

            //widht
            xmlData[3] = xy[0];

            //height
            xmlData[4] = xy[1];
            //product

            switch (xy[2])
            {
                case "lbl":
                    xmlData[0] = "ETIKETA";
                    break;
                case "slee":
                    xmlData[0] = "SLEEVE";
                    break;
                case "lam":
                    xmlData[0] = "TUBA";
                    break;
                case "flex":
                    xmlData[0] = "OBAL";
                    break;
            }

            return xmlData;
        }

        private static bool validate(string[] data)
        {
           
            bool result = false;
            if (data[2].Length>15)
            {
                char[] s = data[2].Take(15).ToArray();
                int i=0;
                int a = 0;
                string value="";
                for (int x = s.Length; x >0; x--)
                {
                    if (s[x-1]=='5')
                    {
                        i += 1;

                    }
                    else
                    {
                        break;
                    }
                }
                for (int z = 0; z <s.Length-1 ; z++)
                {
                    if ( Int32.TryParse(s[z].ToString(), out a))
                    {
                        value+= s[z];

                    }
                    else
                    {
                        break;
                    }
                }
                int seq = Int32.Parse(value) + i;
                if (seq==Int32.Parse(data[3]))
                {
                    result = true;
                }
            }
            return result;
        }
    }
}
