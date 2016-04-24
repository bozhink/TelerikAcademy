namespace CalculateAgain
{
    using System;
    using System.Numerics;

    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            if (k > n)
            {
                int swap = n;
                n = k;
                k = swap;
            }

            int m = k + 1;

            BigInteger result = 1;
            for (int i = m; i <= n; ++i)
            {
                result *= i;
            }

            Console.WriteLine(result);
        }
    }
}