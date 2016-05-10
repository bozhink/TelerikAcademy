namespace TextToXml
{
    using System;
    using System.IO;
    using System.Xml.Linq;

    public class TextToXml
    {
        public static void Main(string[] args)
        {
            string textFileName = "phonebook.txt";

            if (args.Length > 0)
            {
                textFileName = args[0];
            }

            if (!File.Exists(textFileName))
            {
                Console.WriteLine("Please provide a valid file name or put here 'phonebook.txt'");
                Environment.Exit(1);
            }

            XElement phoneBook = new XElement("phoneBook");

            using (StreamReader reader = new StreamReader(textFileName))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (line != null && line.Length > 0)
                    {
                        XElement personRecord = new XElement("person-record");
                        string[] lineData = line.Split(',');
                        int length = lineData.Length;

                        if (length > 0)
                        {
                            XElement name = new XElement("name", lineData[0].Trim());
                            personRecord.Add(name);

                            if (length > 1)
                            {
                                XElement address = new XElement("address", lineData[1].Trim());
                                personRecord.Add(address);

                                if (length > 2)
                                {
                                    XElement phone = new XElement("phone", lineData[2].Trim());
                                    personRecord.Add(phone);
                                }
                            }
                        }

                        phoneBook.Add(personRecord);
                    }
                }
            }

            Console.WriteLine(phoneBook);
        }
    }
}
