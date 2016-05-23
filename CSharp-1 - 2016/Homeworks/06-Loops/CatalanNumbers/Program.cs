namespace CatalanNumbers
{
    using System;
    using System.Numerics;

    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            BigInteger cn = 1;
            BigInteger a = 1;
            BigInteger b = 1;
            for (int k = 2; k <= n; ++k)
            {
                a *= n + k;
                b *= k;
            }

            cn = a / b;

            Console.WriteLine(cn);
        }
    }
}