namespace NegativeNumbersRemover
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var sequence = new List<int> { 1, 2, -123, 12, -3, 12, -3, 12, 31, -32, 12, 3, 123, 1, 23, -12, 3, 123, -12 };
            RemoveNegativeNumbers(sequence);
            Console.WriteLine(string.Join(", ", sequence));
        }

        public static void RemoveNegativeNumbers(IList<int> sequence)
        {
            for (int i = 0; i < sequence.Count;)
            {
                var currentItem = sequence[i];
                if (currentItem < 0)
                {
                    sequence.Remove(currentItem);
                }
                else
                {
                    ++i;
                }
            }
        }
    }
}
