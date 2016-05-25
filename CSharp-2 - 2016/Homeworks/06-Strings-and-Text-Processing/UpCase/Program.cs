namespace UpCase
{
    using System;

    public class Program
    {
        private const string OpenTag = "<upcase>";
        private const string CloseTag = "</upcase>";

        private static readonly int OpenTagLength = OpenTag.Length;
        private static readonly int CloseTagLength = CloseTag.Length;

        public static void Main(string[] args)
        {
            string text = Console.ReadLine();
            Console.WriteLine(ChangeToUpCase(text));
        }

        public static string ChangeToUpCase(string text)
        {
            return ProcessText(text);
        }

        public static string ProcessText(string text)
        {
            int leftIndex = text.IndexOf(OpenTag);
            int rightIndex = text.IndexOf(CloseTag);

            if (leftIndex < 0 || rightIndex < 0 || rightIndex < leftIndex)
            {
                return text;
            }

            int leftTextIndex = leftIndex + OpenTagLength;
            int textLength = rightIndex - leftTextIndex;
            return text.Substring(0, leftIndex) +
                text.Substring(leftTextIndex, textLength).ToUpper() +
                ProcessText(text.Substring(rightIndex + CloseTagLength));
        }
    }
}