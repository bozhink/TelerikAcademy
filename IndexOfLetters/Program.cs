namespace IndexOfLetters
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            char[] array = new char[122 - 96];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = (char)(97 + i);
            }

            int n = array.Length;

            string word = Console.ReadLine();
            foreach (char ch in word)
            {
                for (int i = 0; i < n; ++i)
                {
                    if (ch == array[i])
                    {
                        Console.WriteLine(i);
                    }
                }
            }
        }
    }
}
