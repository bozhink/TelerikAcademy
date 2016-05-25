namespace CorrectBrackets
{
    using System;

    public class Program
    {
        public static bool CheckForCorrect(string text, char leftChar, char rightChar)
        {
            bool iscorrect = true;
            int leftIndex = text.IndexOf(leftChar);
            int rightIndex = text.IndexOf(rightChar);

            while (leftIndex != -1 || rightIndex != -1)
            {
                if (((leftIndex != -1 && rightIndex == -1) || (leftIndex == -1 && rightIndex != -1)) || (leftIndex > rightIndex))
                {
                    iscorrect = false;
                    break;
                }

                leftIndex = text.IndexOf(leftChar, leftIndex + 1);
                rightIndex = text.IndexOf(rightChar, rightIndex + 1);
            }

            return iscorrect;
        }

        public static void Main()
        {
            string inpput = Console.ReadLine();
            bool correct = CheckForCorrect(inpput, '(', ')');

            Console.WriteLine(correct ? "Correct" : "Incorrect");
        }
    }
}