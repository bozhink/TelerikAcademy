namespace DirectoryContentToXml
{
    using System;
    using System.IO;
    using System.Xml.Linq;

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

            XElement directoryTree = GetDirectoryTree(directoryName);
            using (StreamWriter writer = new StreamWriter(outputXmlFileName))
            {
                writer.WriteLine(directoryTree);
            }
        }

        private static XElement GetDirectoryTree(string directoryName)
        {
            XElement currentDirectory = null;

            string initialDirectory = Directory.GetCurrentDirectory();

            try
            {
                Directory.SetCurrentDirectory(directoryName);

                currentDirectory = new XElement("directory", new XAttribute("name", Path.GetFileName(directoryName)));

                foreach (string subdirectory in Directory.GetDirectories(directoryName))
                {
                    XElement directory = GetDirectoryTree(subdirectory);
                    if (directory != null)
                    {
                        currentDirectory.Add(directory);
                    }
                }

                foreach (string file in Directory.GetFiles(directoryName))
                {
                    XElement currentFile = new XElement("file", new XAttribute("name", Path.GetFileName(file)));
                    if (currentFile != null)
                    {
                        currentDirectory.Add(currentFile);
                    }
                }
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

            return currentDirectory;
        }
    }
}
