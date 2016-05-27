namespace ExtractSentences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public static class Program
    {
        private const char SentenceDelimiter = '.';

        public static void Main(string[] args)
        {
            var word = Console.ReadLine();
            var text = Console.ReadLine();
            Console.WriteLine(ExtratSentencesFromText(text, word));
        }

        public static string ExtratSentencesFromText(string text, string word)
        {
            var stringBuilder = new StringBuilder();

            var sentences = text.Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .ToArray();
            for (int i = 0; i < sentences.Length; ++i)
            {
                if (IsWordInSentance(sentences[i], word))
                {
                    stringBuilder.Append(sentences[i]);
                    stringBuilder.Append('.');

                    if (i < sentences.Length)
                    {
                        stringBuilder.Append(" ");
                    }
                }
            }

            return stringBuilder.ToString().Trim();
        }

        public static bool IsWordInSentance(string sentance, string word)
        {
            bool found = false;
            int nextIndexOfWord = sentance.IndexOf(word);
            int lastIndex = sentance.Length - word.Length;

            while (nextIndexOfWord > -1)
            {
                if (nextIndexOfWord != 0 &&
                  (char.IsLetter(sentance[nextIndexOfWord - 1]) ||
                   (sentance[nextIndexOfWord - 1] == '-')))
                {
                    nextIndexOfWord = sentance.IndexOf(word, nextIndexOfWord + 1);
                }
                else if (nextIndexOfWord < lastIndex &&
                    (char.IsLetter(sentance[nextIndexOfWord + word.Length]) ||
                    (sentance[nextIndexOfWord + word.Length] == '-')))
                {
                    nextIndexOfWord = sentance.IndexOf(word, nextIndexOfWord + 1);
                }
                else
                {
                    found = true;
                    break;
                }
            }

            return found;
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