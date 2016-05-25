namespace CorrectBrackets
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        private const string Incorrect = "Incorrect";
        private const string Correct = "Correct";

        public static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var stack = new Stack<char>();
            for (int i = 0; i < input.Length; ++i)
            {
                char ch = input[i];
                switch (ch)
                {
                    case '(':
                        stack.Push(ch);
                        break;

                    case ')':
                        if (stack.Count > 0)
                        {
                            stack.Pop();
                        }
                        else
                        {
                            Console.WriteLine(Incorrect);
                            return;
                        }

                        break;

                    default:
                        break;
                }
            }

            Console.WriteLine(Correct);
        }
    }
}