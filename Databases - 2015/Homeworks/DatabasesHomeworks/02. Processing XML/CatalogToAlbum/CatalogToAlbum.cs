namespace CatalogToAlbum
{
    using System;
    using System.IO;
    using System.Text;
    using System.Xml;

    public class CatalogToAlbum
    {
        public static void Main(string[] args)
        {
            string catalogXmlFileName = "catalog.xml";
            string outputXmlFileName = "album.xml";

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

            XmlWriterSettings writerSettings = new XmlWriterSettings();
            writerSettings.Encoding = Encoding.UTF8;
            writerSettings.Indent = true;

            using (XmlWriter albumsWriter = XmlWriter.Create(outputXmlFileName, writerSettings))
            {
                albumsWriter.WriteStartDocument();
                albumsWriter.WriteStartElement("albums");

                using (XmlReader catalogReader = XmlReader.Create(catalogXmlFileName, readerSettings))
                {
                    while (catalogReader.Read())
                    {
                        if ((catalogReader.NodeType == XmlNodeType.Element) &&
                            (catalogReader.Name == "album"))
                        {
                            albumsWriter.WriteStartElement("album");

                            var subtree = catalogReader.ReadSubtree();
                            while (subtree.Read())
                            {
                                if ((subtree.NodeType == XmlNodeType.Element) &&
                                    (subtree.Name == "name"))
                                {
                                    albumsWriter.WriteElementString("name", subtree.ReadElementString());
                                }

                                if ((subtree.NodeType == XmlNodeType.Element) &&
                                    (subtree.Name == "artist"))
                                {
                                    albumsWriter.WriteElementString("artist", subtree.ReadElementString());
                                }
                            }

                            albumsWriter.WriteEndElement();
                        }
                    }
                }

                albumsWriter.WriteEndElement();
                albumsWriter.WriteEndDocument();
            }
        }
    }
}
