namespace ExtractArtists
{
    using System;
    using System.Collections;
    using System.IO;
    using System.Linq;
    using System.Xml;

    public class ArtistsExtractor
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

            var albumsPerArtist = new Hashtable();
            foreach (XmlNode artist in catalog.SelectNodes("//artist"))
            {
                string artistName = artist.InnerText;
                try
                {
                    albumsPerArtist.Add(artistName, 1);
                }
                catch (ArgumentException)
                {
                    albumsPerArtist[artistName] = int.Parse(albumsPerArtist[artistName].ToString()) + 1;
                }
                catch
                {
                    throw;
                }
            }

            foreach (string artist in albumsPerArtist.Keys.Cast<string>().OrderBy(s => s))
            {
                Console.WriteLine("Artist '{0}' has {1} ablums listed.", artist, albumsPerArtist[artist]);
            }
        }
    }
}
