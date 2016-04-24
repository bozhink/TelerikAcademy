namespace DecimalToBinary
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            long number = long.Parse(Console.ReadLine());

            char[] bits = new char[64];
            int i = 0;
            do
            {
                bits[i++] = (number % 2) == 0 ? '0' : '1';
                number /= 2;
            }
            while (number > 0);

            for (int j = bits.Length - 1; j >= 0; --j)
            {
                Console.Write(bits[j] == '0' ? "0" : bits[j] == '1' ? "1" : string.Empty);
            }

            Console.WriteLine();
        }
    }
}