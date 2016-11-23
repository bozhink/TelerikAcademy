namespace SumAndAverage
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var sequence = new List<int>();

            while (true)
            {
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    break;
                }

                int item;
                if (!int.TryParse(input, out item) || item < 1)
                {
                    Console.WriteLine("Input should be positive integer number but is '{0}'.", input);
                    continue;
                }

                sequence.Add(item);
            }

            long sum = 0L;
            double average = 0.0;
            foreach (var item in sequence)
            {
                sum += item;
            }

            average = (1.0 * sum) / sequence.Count;

            Console.WriteLine("Sum = {0}, Average = {1}", sum, average);
        }
    }
}
