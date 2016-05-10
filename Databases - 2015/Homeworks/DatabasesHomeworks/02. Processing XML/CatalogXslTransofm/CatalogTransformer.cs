namespace CatalogXslTransofm
{
    using System;
    using System.IO;
    using System.Xml.Xsl;

    public class CatalogTransformer
    {
        public static void Main(string[] args)
        {
            string catalogXmlFileName = "catalog.xml";
            string outCatalogXmlFileName = "catalog.html";
            string transofrmXslFile = "catalog.xsl";

            if (args.Length > 0)
            {
                catalogXmlFileName = args[0];
            }

            if (args.Length > 1)
            {
                transofrmXslFile = args[1];
            }

            if (args.Length > 2)
            {
                outCatalogXmlFileName = args[2];
            }

            if (!File.Exists(catalogXmlFileName))
            {
                Console.WriteLine("Please provide a valid file name or put here 'catalog.xml'.");
                Environment.Exit(1);
            }

            if (!File.Exists(transofrmXslFile))
            {
                Console.WriteLine("Please provide a valid xsl file name or put here 'catalog.xsl'.");
                Environment.Exit(1);
            }

            XslCompiledTransform transformer = new XslCompiledTransform();
            transformer.Load(transofrmXslFile);
            transformer.Transform(catalogXmlFileName, outCatalogXmlFileName);
        }
    }
}
