namespace ReverseSequenceWithStack
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var sequence = new Stack<int>();

            while (true)
            {
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    break;
                }

                int item;
                if (!int.TryParse(input, out item))
                {
                    Console.WriteLine("Input should be integer number but is '{0}'.", input);
                    continue;
                }

                sequence.Push(item);
            }

            while (sequence.Count > 0)
            {
                var item = sequence.Pop();
                Console.WriteLine(item);
            }
        }
    }
}
