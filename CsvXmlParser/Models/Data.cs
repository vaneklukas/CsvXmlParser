using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvXmlParser.Models
{
    class Data
    {
        public string Type { get; set; }
        public string Date { get; set; }
        public string Partner { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string  Unit { get; set; }
        public int Amount { get; set; }

        public Data(string type, string date, string partner, int width, int height,string unit, int amount  )
        {
            Type = type;
            Date = date;
            Partner = partner;
            Width = width;
            Height = height;
            Unit = unit;
            Amount = amount;
        }

    }
}
