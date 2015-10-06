namespace DeleteAlbumsByPrice
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml;

    public class ExpensiveAlbumsRemover
    {
        public const decimal MaxPrice = 20.0m;

        public static void Main(string[] args)
        {
            string catalogXmlFileName = "catalog.xml";
            string outputCatalogXmlFileName = "catalog.out.xml";

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

            var documentElement = catalog.DocumentElement;
            List<XmlElement> albumsToBeDeleted = new List<XmlElement>();
            foreach (XmlElement album in documentElement.GetElementsByTagName("album"))
            {
                foreach (XmlNode price in album.GetElementsByTagName("price"))
                {
                    if (decimal.Parse(price.InnerText) > MaxPrice)
                    {
                        albumsToBeDeleted.Add(album);
                        break;
                    }
                }
            }

            foreach (XmlElement album in albumsToBeDeleted)
            {
                album.ParentNode.RemoveChild(album);
            }

            XmlWriterSettings writerSettings = new XmlWriterSettings();
            writerSettings.Indent = true;
            using (XmlWriter writer = XmlWriter.Create(outputCatalogXmlFileName, writerSettings))
            {
                catalog.WriteContentTo(writer);
            }
        }
    }
}
