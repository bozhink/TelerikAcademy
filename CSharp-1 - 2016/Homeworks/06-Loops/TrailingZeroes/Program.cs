namespace TrailingZeroes
{
    using System;
    using System.Numerics;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            BigInteger factorial = 1;
            for (int i = 0; i < n;)
            {
                factorial *= ++i;
            }

            string stringValue = factorial.ToString();
            string trailingZeroes = Regex.Match(stringValue, @"0+\Z").Value;

            Console.WriteLine(trailingZeroes.Length);
        }
    }
}