namespace StringLength
{
    using System;

    public class Program
    {
        private const int MaximalLength = 20;
        private const char FillingChar = '*';

        public static void Main(string[] args)
        {
            string input = Console.ReadLine().Replace(@"\", string.Empty);
            Console.WriteLine(input.PadRight(MaximalLength, FillingChar));
        }
    }
}