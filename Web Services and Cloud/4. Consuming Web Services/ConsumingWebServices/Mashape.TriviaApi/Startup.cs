namespace Mashape.TriviaApi
{
    using System;
    using System.Diagnostics;
    using System.Text.RegularExpressions;

    public class Startup
    {
        private static readonly Regex MatchFakeHtmlTags = new Regex("&lt;[^&]+&gt;|&amp;|&nbsp;");

        public static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                PrintHelp();
            }

            int pageNumber, itemsPerPage;

            if (!int.TryParse(args[0], out pageNumber))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid page number: {0}", args[0]);
                Console.ResetColor();
                Environment.Exit(2);
            }

            if (!int.TryParse(args[1], out itemsPerPage))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid page number: {0}", args[1]);
                Console.ResetColor();
                Environment.Exit(2);
            }

            var questionRequester = new QuestionRequester();
            var questions = questionRequester
                .Get(
                    pageNumber: pageNumber,
                    itemsPerPage: itemsPerPage)
                .Result;

            int i = 0;
            foreach (var question in questions)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("{0}.", ++i);
                Console.ResetColor();

                Console.WriteLine(
                    " {0}\n\t(1) {1}\n\t(2) {2}\n\t(3) {3}\n\t(4) {4}",
                    MatchFakeHtmlTags.Replace(question.Text, string.Empty),
                    MatchFakeHtmlTags.Replace(question.Options1, string.Empty),
                    MatchFakeHtmlTags.Replace(question.Options2, string.Empty),
                    MatchFakeHtmlTags.Replace(question.Options3, string.Empty),
                    MatchFakeHtmlTags.Replace(question.Options4, string.Empty));

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("Answer: ({0})", question.CorrectOption);
                Console.ResetColor();

                Console.WriteLine();
            }
        }

        private static void PrintHelp()
        {
            Console.WriteLine(
                "\nUsage: {0} <page number> <items per page>\n",
                Process.GetCurrentProcess().ProcessName);

            Environment.Exit(1);
        }
    }
}