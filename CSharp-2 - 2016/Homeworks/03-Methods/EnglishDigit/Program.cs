namespace EnglishDigit
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();

            int digit = int.Parse(input[input.Length - 1].ToString());

            Console.WriteLine(DigitAsWord(digit));
        }

        public static string DigitAsWord(int digit)
        {
            switch (digit)
            {
                case 0:
                    return "zero";

                case 1:
                    return "one";

                case 2:
                    return "two";

                case 3:
                    return "three";

                case 4:
                    return "four";

                case 5:
                    return "five";

                case 6:
                    return "six";

                case 7:
                    return "seven";

                case 8:
                    return "eight";

                case 9:
                    return "nine";

                default:
                    return "not a digit";
            }
        }
    }
}