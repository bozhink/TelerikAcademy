namespace LongestSubsequence
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var sequence = new List<int> { 1, 1, 2, 4, 1, 1, 1, 1, 5, 6, 4, 4, 4, 4, 6, 6, 6, 6, 666, 6, 7, 7, 7, 8, 8, 8 };
            Console.WriteLine(string.Join(", ", FindLongestSubsequence(sequence)));
        }

        public static List<int> FindLongestSubsequence(List<int> sequence)
        {
            if (sequence == null)
            {
                throw new ArgumentNullException(nameof(sequence));
            }

            if (sequence.Count == 0)
            {
                return new List<int>();
            }

            var longestSubsequence = new Queue<int>();

            var lastDifferentItem = sequence[0];
            var testSubsequence = new Queue<int>();
            testSubsequence.Enqueue(lastDifferentItem);

            for (int i = 1; i < sequence.Count; i++)
            {
                var currentItem = sequence[i];

                if (currentItem == lastDifferentItem)
                {
                    testSubsequence.Enqueue(currentItem);
                }
                else
                {
                    if (longestSubsequence.Count < testSubsequence.Count)
                    {
                        longestSubsequence = testSubsequence;
                    }

                    lastDifferentItem = currentItem;
                    testSubsequence = new Queue<int>();
                    testSubsequence.Enqueue(lastDifferentItem);
                }
            }

            return new List<int>(longestSubsequence);
        }
    }
}
