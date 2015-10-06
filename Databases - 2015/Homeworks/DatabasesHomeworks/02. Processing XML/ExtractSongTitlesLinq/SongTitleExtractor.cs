namespace ExtractSongTitlesLinq
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;

    public class SongTitleExtractor
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

            XDocument catalog = XDocument.Load(catalogXmlFileName);
            var songTitles = from song in catalog.Descendants("song")
                        select song.Element("title").Value;

            foreach (string title in songTitles)
            {
                Console.WriteLine(title);
            }
        }
    }
}
