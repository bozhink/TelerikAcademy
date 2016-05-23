namespace ConsoleApplication3
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            long sumOfSums = 0;
            for (int x = a; x <= b; ++x)
            {
                sumOfSums += SumOfOddDivisors(x);
            }

            Console.WriteLine(sumOfSums);
        }

        public static long SumOfOddDivisors(int x)
        {
            long result = 0;
            for (int i = 1; i <= x; i += 2)
            {
                if (x % i == 0)
                {
                    result += i;
                }
            }

            return result;
        }
    }
}