namespace ExtractSentences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public static class Program
    {
        private const char SentenceDelimiter = '.';

        public static void Main(string[] args)
        {
            string word = Console.ReadLine();
            string text = Console.ReadLine();

            var matchingSentences = GetSentencesContainingWord(word, text);

            Console.WriteLine(string.Join(string.Empty, matchingSentences));
        }

        public static IEnumerable<string> GetSentencesContainingWord(string word, string text)
        {
            Regex matchSentence = new Regex(@"[^\.]*\.", RegexOptions.Compiled);

            string wordPattern = word.GetMatchWordPattern();
            Regex matchWord = new Regex(wordPattern, RegexOptions.Compiled/* | RegexOptions.IgnoreCase*/);

            var matchingSentences = text.GetMatches(matchSentence)
                .Where(s => matchWord.IsMatch(s));

            return matchingSentences;
        }

        public static IEnumerable<string> GetMatches(this string text, Regex re)
        {
            for (Match m = re.Match(text); m.Success; m = m.NextMatch())
            {
                yield return m.Value;
            }
        }

        public static string GetMatchWordPattern(this string word)
        {
            Regex matchNonTextInBeginning = new Regex(@"\A\W+", RegexOptions.Compiled);
            Regex matchNonTextInEnd = new Regex(@"\W+\Z", RegexOptions.Compiled);

            string pattern = Regex.Escape(word);

            if (!matchNonTextInBeginning.IsMatch(word))
            {
                pattern = @"\b" + pattern;
            }

            if (!matchNonTextInEnd.IsMatch(word))
            {
                pattern = pattern + @"\b";
            }

            return pattern;
        }
    }
}