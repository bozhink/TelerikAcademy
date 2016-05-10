using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Saxon.Api;
using System.IO;
using System.Xml;

namespace XQueryTransform
{
    public class XQueryTransofrmer
    {
        public static void Main(string[] args)
        {
            string catalogXmlFileName = "catalog.xml";
            string queryFileName = "query.xquery";
            string outputFileName = "catalog.html";

            if (args.Length > 0)
            {
                catalogXmlFileName = args[0];
            }

            if (args.Length > 1)
            {
                queryFileName = args[1];
            }

            if (!File.Exists(catalogXmlFileName))
            {
                Console.WriteLine("Please provide a valid file name or put here 'catalog.xml'.");
                Environment.Exit(1);
            }

            if (!File.Exists(queryFileName))
            {
                Console.WriteLine("Please provide a valid XQuery file name or put here 'query.xquery'.");
                Environment.Exit(1);
            }

            XmlDocument catalogXml = new XmlDocument();
            catalogXml.PreserveWhitespace = true;
            catalogXml.Load(catalogXmlFileName);

            Processor processor = new Processor();
            
            //Input loaded from xml file
            XdmNode inputDocument = processor.NewDocumentBuilder().Build(catalogXml.DocumentElement);

            //XQuery loaded from text file
            XQueryCompiler compiler = processor.NewXQueryCompiler();
            XQueryEvaluator evaluator = null;
            using (StreamReader queryFile = new StreamReader(File.Open(queryFileName, FileMode.Open)))
            {
                XQueryExecutable executable = compiler.Compile(queryFile.ReadToEnd());
                evaluator = executable.Load();
                evaluator.ContextItem = inputDocument;
            }

            using (StreamWriter writer = new StreamWriter(outputFileName))
            {
                Serializer serializer = new Serializer();
                serializer.SetOutputProperty(Serializer.METHOD, "xml");
                serializer.SetOutputProperty(Serializer.DOCTYPE_PUBLIC, "-//W3C//DTD XHTML 1.0 Strict//EN");
                serializer.SetOutputProperty(Serializer.DOCTYPE_SYSTEM, "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd");
                serializer.SetOutputProperty(Serializer.INDENT, "yes");
                serializer.SetOutputProperty(Serializer.OMIT_XML_DECLARATION, "no");

                serializer.SetOutputWriter(writer);
                evaluator.Run(serializer);
            }
        }
    }
}
