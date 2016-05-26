namespace ReplaceTags
{
    using System;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Regex matchAnchor = new Regex(@"<a\b[^>]+href=""([^""<>]+)""[^>]*>([\s\S]*?)</a>");

            string result = matchAnchor.Replace(input, "[$2]($1)");

            Console.WriteLine(result);
        }
    }
}