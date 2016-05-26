namespace SequenceOfLetters
{
    using System;
    using System.Text;

    public class Program
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Console.WriteLine(ReplaceSequentalLetter(input));
        }

        public static string ReplaceSequentalLetter(string input)
        {
            if (input.Length < 1)
            {
                return input;
            }

            var stringBuilder = new StringBuilder();

            char lastCharacter = input[0];
            stringBuilder.Append(lastCharacter);

            for (int i = 1; i < input.Length; ++i)
            {
                if (input[i] == lastCharacter)
                {
                    continue;
                }

                lastCharacter = input[i];
                stringBuilder.Append(lastCharacter);
            }

            return stringBuilder.ToString();
        }
    }
}