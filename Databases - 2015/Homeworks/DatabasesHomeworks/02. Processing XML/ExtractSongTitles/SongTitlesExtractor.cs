namespace ExtractSongTitles
{
    using System;
    using System.IO;
    using System.Xml;

    public class SongTitlesExtractor
    {
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

            XmlReaderSettings readerSettings = new XmlReaderSettings();
            readerSettings.IgnoreComments = true;
            readerSettings.IgnoreProcessingInstructions = true;
            readerSettings.IgnoreWhitespace = false;
            using (XmlReader catalogReader = XmlReader.Create(catalogXmlFileName, readerSettings))
            {
                while (catalogReader.Read())
                {
                    if ((catalogReader.NodeType == XmlNodeType.Element) &&
                        (catalogReader.Name == "title"))
                    {
                        Console.WriteLine(catalogReader.ReadElementString());
                    }
                }
            }
        }
    }
}
