namespace MaximalIncreasingSequence
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];
            for (int i = 0; i < n; ++i)
            {
                array[i] = int.Parse(Console.ReadLine());
            }

            int maximalSequenceLength = 0;
            int sequenceLength = 1;
            for (int i = 1; i < n; ++i)
            {
                if (array[i] > array[i-1])
                {
                    sequenceLength++;
                    if (maximalSequenceLength < sequenceLength)
                    {
                        maximalSequenceLength = sequenceLength;
                    }
                }
                else
                {
                    sequenceLength = 1;
                }
            }

            Console.WriteLine(maximalSequenceLength);
        }
    }
}