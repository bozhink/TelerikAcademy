namespace AnimalHierarchy.Tests
{
    using System;
    using System.Linq;
    using Models;

    public class Program
    {
        private const int NumberOfAnimalsPerGroup = 10;

        private static Random random = new Random();

        public static void Main(string[] args)
        {
            TestFrogs();
            Console.WriteLine();
            TestKittens();
        }

        private static void TestFrogs()
        {
            var animals = Enumerable.Range(0, NumberOfAnimalsPerGroup)
                .Select(i => new Frog(i.ToString(), (decimal)random.NextDouble(), Sex.Other))
                .ToArray();

            decimal meanAge = CalculateMeanAge(animals);
            Console.WriteLine(meanAge);
            animals.ToList().ForEach(Console.WriteLine);
        }

        private static void TestKittens()
        {
            var animals = Enumerable.Range(0, NumberOfAnimalsPerGroup)
                .Select(i => new Kitten(i.ToString(), (decimal)random.NextDouble()))
                .ToArray();

            decimal meanAge = CalculateMeanAge(animals);
            Console.WriteLine(meanAge);
            animals.ToList().ForEach(Console.WriteLine);
        }

        private static decimal CalculateMeanAge(Animal[] animals)
        {
            return animals.Sum(a => a.Age) / NumberOfAnimalsPerGroup;
        }
    }
}
