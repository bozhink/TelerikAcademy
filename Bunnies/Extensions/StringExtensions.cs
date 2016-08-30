namespace Bunnies.Extensions
{
    using System.Text;

    public static class StringExtensions
    {
        private const int ProbableStringMargin = 10;
        private const char SingleWhitespace = ' ';

        public static string SplitToSeparateWordsByUppercaseLetter(this string sequence)
        {
            var probableStringSize = sequence.Length + ProbableStringMargin;
            var builder = new StringBuilder(probableStringSize);

            foreach (var letter in sequence)
            {
                if (char.IsUpper(letter))
                {
                    builder.Append(SingleWhitespace);
                }

                builder.Append(letter);
            }

            return builder.ToString().Trim();
        }
    }
}
