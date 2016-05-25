namespace ReverseString
{
    using System;
    using System.Text;

    public class Program
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var stringBuilder = new StringBuilder();

            for (int i = input.Length - 1; i >= 0; --i)
            {
                stringBuilder.Append(input[i]);
            }

            Console.WriteLine(stringBuilder.ToString());
        }
    }
}