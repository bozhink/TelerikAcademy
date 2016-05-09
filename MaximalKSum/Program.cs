namespace MaximalKSum
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            int[] array = new int[n];
            for (int i = 0; i < n; ++i)
            {
                array[i] = int.Parse(Console.ReadLine());
            }

            long maximalKSum = 0;
            for (int i = 0; i < n; ++i)
            {
                long sum = 0;
                for (int j = 0; j < k; ++j)
                {

                }
            }
        }
    }
}