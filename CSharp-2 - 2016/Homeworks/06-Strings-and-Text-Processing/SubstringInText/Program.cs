namespace SubstringInText
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            string pattern = Console.ReadLine();
            string text = Console.ReadLine();

            Console.WriteLine(CountNumberOfOcurrences(text, pattern));
        }

        public static int CountNumberOfOcurrences(string text, string pattern)
        {
            int result = 0;

            int index = -1;

            for (int i = 0; i < text.Length; ++i)
            {
                index = text.IndexOf(pattern, index + 1, StringComparison.InvariantCultureIgnoreCase);

                if (index >= 0)
                {
                    ++result;
                    i = index;
                }
                else
                {
                    break;
                }
            }

            return result;
        }
    }
}