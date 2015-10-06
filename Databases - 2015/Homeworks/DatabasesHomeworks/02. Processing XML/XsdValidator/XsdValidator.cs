using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Schema;

namespace XsdValidator
{
    public class XsdValidator
    {
        public static void Main(string[] args)
        {
            string catalogXmlFileName = "catalog.xml";
            string catalogXsdFileName = "catalog.xsd";

            if (args.Length > 0)
            {
                catalogXmlFileName = args[0];
            }

            if (args.Length > 1)
            {
                catalogXsdFileName = args[1];
            }

            if (!File.Exists(catalogXmlFileName))
            {
                Console.WriteLine("Please provide a valid XML file name or put here 'catalog.xml'.");
                Environment.Exit(1);
            }

            if (!File.Exists(catalogXsdFileName))
            {
                Console.WriteLine("Please provide a valid XSD file name or put here 'catalog.xsd'.");
                Environment.Exit(1);
            }

            XmlSchemaSet schema = new XmlSchemaSet();
            schema.Add(string.Empty, catalogXsdFileName);

            XDocument catalog = XDocument.Load(catalogXmlFileName);

            catalog.Validate(schema, (o, e) =>
            {
                Console.WriteLine(e.Message);
            });
        }
    }
}
