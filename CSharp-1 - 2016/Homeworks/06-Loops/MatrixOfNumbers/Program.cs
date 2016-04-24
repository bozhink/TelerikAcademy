namespace MatrinOfNumbers
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    Console.Write(i + j);
                    if (j != n - 1)
                    {
                        Console.Write(" ");
                    }
                }

                Console.WriteLine();
            }
        }
    }
}