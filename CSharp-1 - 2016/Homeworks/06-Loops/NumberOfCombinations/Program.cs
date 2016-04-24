namespace NumberOfCombinations
{
    using System;
    using System.Numerics;

    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            BigInteger a = 1;
            for (int i = k + 1; i <= n; ++i)
            {
                a *= i;
            }

            BigInteger b = 1;
            for (int i = 1; i <= n - k; ++i)
            {
                b *= i;
            }

            Console.WriteLine(a / b);
        }
    }
}