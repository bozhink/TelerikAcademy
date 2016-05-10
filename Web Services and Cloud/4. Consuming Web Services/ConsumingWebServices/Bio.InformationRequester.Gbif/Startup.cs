/// <summary>
/// Global Biodiversity Information Facility (GBIF)
/// http://www.gbif.org
/// </summary>
namespace Bio.InformationRequester.Gbif
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            string input;
            while (true)
            {
                Console.Write("Enter species name to search (? for suggestions, ! to exit): ");
                try
                {
                    input = Console.ReadLine();
                    char firstChar = input.Trim().ToCharArray()[0];
                    if (firstChar == '?')
                    {
                        PrintHelp();
                    }
                    else if (firstChar == '!')
                    {
                        Environment.Exit(0);
                    }
                    else
                    {
                        break;
                    }
                }
                catch
                {
                    continue;
                }
            }

            var requester = new GbifRequester();

            var response = requester.GetSpeciesInformation(input).Result;

            Console.WriteLine(response.CanonicalName);
            Console.WriteLine(response.ScientificName);
            Console.WriteLine(response.Rank);
        }

        private static void PrintHelp()
        {
            Console.WriteLine("Examples:");
            Console.WriteLine("  Drosophila melanogaster");
            Console.WriteLine("  Escherichia coli");
            Console.WriteLine("  Coccinella septempunctata");
            Console.WriteLine("  Homo sapiens");
        }
    }
}