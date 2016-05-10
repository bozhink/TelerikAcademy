namespace HexToDecimal
{
    using System;

    public class Program
    {
        private const string Alphabet = "0123456789ABCDEF";
        private static readonly int BaseLenght = Alphabet.Length;

        public static void Main(string[] args)
        {
            string input = Console.ReadLine().ToUpper();

            char[] inputAsChars = input.ToCharArray();
            int length = inputAsChars.Length;

            long result = 0;
            long powerOfBase = 1;
            for (int i = length - 1; i >= 0; --i)
            {
                char cifer = inputAsChars[i];

                int value = Alphabet.IndexOf(cifer);

                result += value * powerOfBase;
                powerOfBase *= BaseLenght;
            }

            Console.WriteLine(result);
        }
    }
}