using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberOfOccurences
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            var sequence = new int[] { 3, 4, 4, 2, 3, 3, 4, 3, 2 };
            var ocurrences = CountOcurrences(sequence);

            // TODO: print
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
