namespace DirectoryContentToXml
{
    using System;
    using System.IO;
    using System.Text;
    using System.Xml;

    public class DirectoryToXml
    {
        public static void Main(string[] args)
        {
            string initialDirectory = Directory.GetCurrentDirectory();
            string directoryName = initialDirectory;
            string outputXmlFileName = initialDirectory + "\\directory.xml";

            if (args.Length > 0)
            {
                directoryName = args[0];
            }

            if (!Directory.Exists(directoryName))
            {
                Console.WriteLine("Please provide a valid directory name.");
                Environment.Exit(1);
            }

            XmlWriterSettings writerSettings = new XmlWriterSettings();
            writerSettings.Encoding = Encoding.UTF8;
            writerSettings.Indent = true;

            using (XmlWriter directoryContentWriter = XmlWriter.Create(outputXmlFileName, writerSettings))
            {
                directoryContentWriter.WriteStartDocument();

                WriteDirectoryTree(directoryContentWriter, directoryName);

                directoryContentWriter.WriteEndDocument();
            }   
        }

        private static void WriteDirectoryTree(XmlWriter writer, string directoryName)
        {
            string initialDirectory = Directory.GetCurrentDirectory();

            try
            {
                Directory.SetCurrentDirectory(directoryName);

                writer.WriteStartElement("directory");
                writer.WriteAttributeString("name", Path.GetFileName(directoryName));

                string[] subdirectories = Directory.GetDirectories(directoryName);
                foreach (string subdirectory in subdirectories)
                {
                    WriteDirectoryTree(writer, subdirectory);
                }

                string[] files = Directory.GetFiles(directoryName);
                foreach (string file in files)
                {
                    writer.WriteStartElement("file");
                    writer.WriteAttributeString("name", Path.GetFileName(file));
                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine("Directory '{0}' not found.\n{1}", directoryName, e.Message);
            }
            catch
            {
                throw;
            }

            Directory.SetCurrentDirectory(initialDirectory);
        }
    }
}
