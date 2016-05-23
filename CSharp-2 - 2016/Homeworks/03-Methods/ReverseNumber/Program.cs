namespace ReverseNumber
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            decimal n = decimal.Parse(Console.ReadLine());

            Console.WriteLine(ReverseNumber(n));
        }

        public static decimal ReverseNumber(decimal n)
        {
            var numberAsChars = n.ToString().ToCharArray();
            int length = numberAsChars.Length;

            for (int i = 0; i < length / 2; ++i)
            {
                Swap(numberAsChars, i, length - 1 - i);
            }

            decimal result = decimal.Parse(string.Join(string.Empty, numberAsChars));

            return result;
        }

        public static void Swap(char[] array, int i, int j)
        {
            var swap = array[i];
            array[i] = array[j];
            array[j] = swap;
        }
    }
}
