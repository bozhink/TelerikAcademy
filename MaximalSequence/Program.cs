namespace MaximalSequence
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            if (n < 1)
            {
                return;
            }

            int[] array = new int[n];
            for (int i = 0; i < n; ++i)
            {
                array[i] = int.Parse(Console.ReadLine());
            }

            int maximalSequenceLength = 1;
            int sequenceLength = 1;
            int sequenceInteger = array[0];
            for (int i = 1; i < n; ++i)
            {
                if (array[i] == sequenceInteger)
                {
                    sequenceLength++;
                }
                else
                {
                    sequenceInteger = array[i];
                    if (maximalSequenceLength < sequenceLength)
                    {
                        maximalSequenceLength = sequenceLength;
                    }

                    sequenceLength = 1;
                }
            }

            Console.WriteLine(maximalSequenceLength);
        }
    }
}