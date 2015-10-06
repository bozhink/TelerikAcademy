namespace PricesXPath
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;

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

            XDocument catalog = null;

            try
            {
                catalog = XDocument.Load(catalogXmlFileName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(1);
            }

            DateTime now = DateTime.Now;
            var prices = from album in catalog.Descendants("album")
                         where (now.Year - int.Parse(album.Element("year").Value)) < YearsAgo
                         select album.Element("price").Value;

            foreach (var price in prices)
            {
                Console.WriteLine(price);
            }
        }
    }
}
