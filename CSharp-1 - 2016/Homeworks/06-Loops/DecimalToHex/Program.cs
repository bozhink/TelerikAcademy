namespace DecimalToHex
{
    using System;

    public class Program
    {
        private const int Base = 16;
        private const string Alphabet = "0123456789ABCDEF";

        public static void Main(string[] args)
        {
            long number = long.Parse(Console.ReadLine());

            char[] bits = new char[64];
            int i = 0;
            do
            {
                bits[i++] = Alphabet.ToCharArray()[(int)(number % Base)];
                number /= Base;
            }
            while (number > 0);

            for (int j = bits.Length - 1; j >= 0; --j)
            {
                string cifer = bits[j].ToString();
                if (Alphabet.Contains(cifer))
                {
                    Console.Write(cifer);
                }
            }

            Console.WriteLine();
        }
    }
}