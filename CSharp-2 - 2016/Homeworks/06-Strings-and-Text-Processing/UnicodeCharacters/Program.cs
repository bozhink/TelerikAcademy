namespace UnicodeCharacters
{
    using System;
    using System.Text;

    public class Program
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Console.WriteLine(GetUnicodeString(input));
        }

        public static string GetUnicodeString(string s)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < s.Length; ++i)
            {
                char c = s[i];
                sb.Append(@"\u");
                sb.Append(string.Format("{0:X4}", (int)c));
            }

            return sb.ToString();
        }
    }
}