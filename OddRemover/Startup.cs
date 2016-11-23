namespace OddRemover
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        // {4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2} → {5, 3, 3, 5}
        public static void Main(string[] args)
        {
            var sequence = new List<int> { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };
            Console.WriteLine(string.Join(", ", sequence));
            RemoveOddOcurrences(sequence);
            Console.WriteLine(string.Join(", ", sequence));
        }

        public static void RemoveOddOcurrences(IList<int> sequence)
        {
            var differentItems = sequence.Distinct().ToArray();
            var numberOfOccurences = new int[differentItems.Length];

            for (int i = 0; i < differentItems.Length; i++)
            {
                var item = differentItems[i];
                numberOfOccurences[i] = sequence.Count(x => x == item);
            }

            for (int i = 0; i < numberOfOccurences.Length; i++)
            {
                if (numberOfOccurences[i] % 2 == 1)
                {
                    var itemToRemove = differentItems[i];

                    while (sequence.Remove(itemToRemove))
                    {
                        // Empty
                    }
                }
            }
        }
    }
}
