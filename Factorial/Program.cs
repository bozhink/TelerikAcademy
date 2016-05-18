namespace Factorial
{
    using System;
    using System.Numerics;

    public class Program
    {
        public static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int[] array = new int[number];

            for (int i = 0; i < array.Length; ++i)
            {
                array[i] = i + 1;
            }

            Console.WriteLine(CalculateFactorial(array));
        }

        public static BigInteger CalculateFactorial(int[] array)
        {
            BigInteger result = 1;
            for (int i = 0; i < array.Length; ++i)
            {
                result *= array[i];
            }

            return result;
        }
    }
}
