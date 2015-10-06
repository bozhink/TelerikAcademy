namespace PricesXPath
{
    using System;
    using System.IO;
    using System.Xml;

    public class PricesExtractor
    {
        public const int YearsAgo = 5;

        public static void Main(string[] args)
        {
            string catalogXmlFileName = "catalog.xml";

            if (args.Length > 0)
            {
                catalogXmlFileName = args[0];
            }

            if (!File.Exists(catalogXmlFileName))
            {
                Console.WriteLine("Please provide a valid file name or put here 'catalog.xml'");
                Environment.Exit(1);
            }

            var catalog = new XmlDocument();
            catalog.PreserveWhitespace = true;

            try
            {
                catalog.Load(catalogXmlFileName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(1);
            }

            DateTime now = DateTime.Now;

            foreach (XmlNode price in catalog.SelectNodes("//album[(" + now.Year + " - number(year)) <= " + YearsAgo + "]/price"))
            {
                Console.WriteLine(price.InnerText);
            }
        }
    }
}
