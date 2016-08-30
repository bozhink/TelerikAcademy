namespace Bunnies
{
    using System.Collections.Generic;
    using System.IO;

    public class Startup
    {
        private const string BunniesFilePath = @"..\..\bunnies.txt";

        private static void Main(string[] args)
        {
            var bunnies = new List<Bunny>
            {
                new Bunny
                {
                    Age = 1,
                    Name = "Leonid",
                    FurType = FurType.NotFluffy
                },
                new Bunny
                {
                    Age = 2,
                    Name = "Rasputin",
                    FurType = FurType.ALittleFluffy
                },
                new Bunny
                {
                    Age = 3,
                    Name = "Tiberii",
                    FurType = FurType.ALittleFluffy
                },
                new Bunny
                {
                    Age = 1,
                    Name = "Neron",
                    FurType = FurType.ALittleFluffy
                },
                new Bunny
                {
                    Age = 3,
                    Name = "Klavdii",
                    FurType = FurType.Fluffy
                },
                new Bunny
                {
                    Age = 3,
                    Name = "Vespasian",
                    FurType = FurType.Fluffy
                },
                new Bunny
                {
                    Age = 4,
                    Name = "Domician",
                    FurType = FurType.FluffyToTheLimit
                },
                new Bunny
                {
                    Age = 2,
                    Name = "Tit",
                    FurType = FurType.FluffyToTheLimit
                }
            };

            IntroduceAllBunnies(bunnies);

            CreateBunniesTextFile();

            SaveBunniesToTextFile(bunnies, BunniesFilePath);
        }

        private static void SaveBunniesToTextFile(List<Bunny> bunnies, string bunniesFilePath)
        {
            using (var streamWriter = new StreamWriter(bunniesFilePath))
            {
                foreach (var bunny in bunnies)
                {
                    streamWriter.WriteLine(bunny.ToString());
                }
            }
        }

        private static void CreateBunniesTextFile()
        {
            var fileStream = File.Create(BunniesFilePath);
            fileStream.Close();
        }

        private static void IntroduceAllBunnies(List<Bunny> bunnies)
        {
            var consoleWriter = new ConsoleWriter();
            foreach (var bunny in bunnies)
            {
                bunny.Introduce(consoleWriter);
            }
        }
    }
}
