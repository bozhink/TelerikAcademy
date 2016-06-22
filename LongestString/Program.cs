namespace LongestString
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Usage: {0} <string1>[ <string2>, ...]", AppDomain.CurrentDomain.FriendlyName);
                Environment.Exit(1);
            }

            string longestString = args.FirstOrDefault(x => x.Length == args.Max(y => y.Length));
            Console.WriteLine(longestString);
        }
    }
}
