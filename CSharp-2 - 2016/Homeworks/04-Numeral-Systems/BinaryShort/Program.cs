namespace BinaryShort
{
    using System;
    using System.Text;
    
    public class Program
    {
        private const string Alphabet = "01";

        public static void Main(string[] args)
        {
            short n = short.Parse(Console.ReadLine());

            var stringBuilder = new StringBuilder();

            for (int i = 0; i < 16; ++i)
            {
                stringBuilder.Insert(0, Alphabet[n & 1]);
                n >>= 1;
            }

            Console.WriteLine(stringBuilder.ToString().PadLeft(16, '0'));
        }
    }
}
