using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvXmlParser.Models.Customers
{
    class DefaultCustomerRules
    {
        public static void writexml(string[]data)
        {
            Xml xml = new Xml();
            xml.write(data);
        }
        public static void writeError(string[] data)
        {
            ErrorLog log = new ErrorLog();
            log.writeValidationError(data);
        }
    }
}
