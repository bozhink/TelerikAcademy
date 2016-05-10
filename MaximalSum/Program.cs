namespace MaximalSum
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

            int maximalSum = array[0];
            int currentMaximalSum = array[0];
            for (int i = 1; i < n; ++i)
            {
                currentMaximalSum = Math.Max(array[i], currentMaximalSum + array[i]);
                maximalSum = Math.Max(currentMaximalSum, maximalSum);
            }

            Console.WriteLine(maximalSum);
        }
    }
}
