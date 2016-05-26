namespace ParseUrl
{
    using System;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Regex matchUrl = new Regex(@"(?<protocol>[A-Za-z]+)://(?<server>[^/]+)(?<resource>/.*)");

            var parts = matchUrl.Match(input);
            var protocol = parts.Groups["protocol"].Value;
            var server = parts.Groups["server"].Value;
            var resource = parts.Groups["resource"].Value;

            Console.WriteLine("[protocol] = {0}", protocol);
            Console.WriteLine("[server] = {0}", server);
            Console.WriteLine("[resource] = {0}", resource);
        }
    }
}