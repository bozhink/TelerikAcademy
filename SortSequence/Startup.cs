namespace SortSequence
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
                if (!int.TryParse(input, out item))
                {
                    Console.WriteLine("Input should be integer number but is '{0}'.", input);
                    continue;
                }

                sequence.Add(item);
            }

            sequence.Sort();

            Console.WriteLine(string.Join(", ", sequence));
        }
    }
}
