namespace NumberOfOccurences
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var sequence = new int[] { 3, 4, 4, 2, 3, 3, 4, 3, 2 };
            var occurrences = CountOcurrences(sequence);

            for (int i = 0; i < occurrences.GetLength(0); i++)
            {
                Console.WriteLine("{0} → {1} times", occurrences[i, 0], occurrences[i, 1]);
            }
        }

        public static int[,] CountOcurrences(int[] sequence)
        {
            var uniqueElements = new List<int>(sequence.Length);
            for (int i = 0; i < sequence.Length; i++)
            {
                var currentItem = sequence[i];
                if (!uniqueElements.Contains(currentItem))
                {
                    uniqueElements.Add(currentItem);
                }
            }

            uniqueElements.TrimExcess();

            int numberOfUniqueElement = uniqueElements.Count;

            var result = new int[numberOfUniqueElement, 2];
            for (int i = 0; i < numberOfUniqueElement; i++)
            {
                result[i, 0] = uniqueElements[i];
            }

            for (int i = 0; i < numberOfUniqueElement; i++)
            {
                var currentItem = result[i, 0];
                foreach (var item in sequence)
                {
                    if (item == currentItem)
                    {
                        result[i, 1]++;
                    }
                }
            }

            return result;
        }
    }
}
