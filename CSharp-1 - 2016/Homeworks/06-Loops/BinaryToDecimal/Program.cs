namespace BinaryToDecimal
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();
            int length = input.Length;

            long result = 0;
            long multiplier = 1;
            for (int i = length - 1; i >= 0; --i)
            {
                result += (input[i] == '0' ? 0 : 1) * multiplier;
                multiplier *= 2;
            }

            Console.WriteLine(result);
        }
    }
}