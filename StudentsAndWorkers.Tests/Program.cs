namespace StudentsAndWorkers.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Models;

    public class Program
    {
        private const int NumberOfTestStudents = 10;
        private const int NumberOfTestWorkers = NumberOfTestStudents;

        private static Random random = new Random();

        public static void Main(string[] args)
        {
            var students = Enumerable.Range(0, NumberOfTestStudents)
                .Select(i => new Student(i.ToString(), random.Next(100, 500).ToString(), (decimal)random.NextDouble()))
                .OrderBy(s => s.Grade)
                .ToList();

            students.ForEach(Console.WriteLine);

            Console.WriteLine();

            var workers = Enumerable.Range(0, NumberOfTestStudents)
                .Select(i => new Worker(i.ToString(), random.Next(100, 500).ToString(), random.Next(6, 24), (decimal)random.NextDouble()))
                .OrderBy(s => s.MoneyPerHour())
                .ToList();

            workers.ForEach(Console.WriteLine);

            Console.WriteLine();

            var humans = workers.Concat<Human>(students)
                .OrderBy(h => h.FirstName)
                .ThenBy(h => h.LastName)
                .ToList();

            humans.ForEach(Console.WriteLine);
        }
    }
}
