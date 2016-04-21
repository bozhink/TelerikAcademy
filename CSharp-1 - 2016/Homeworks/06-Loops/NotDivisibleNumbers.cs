namespace NotDivisibleNumbers
{
    using System;
    
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            System.Console.Write(1);
            for (int i = 2; i <= n; ++i)
            {
                if (i % 3 != 0 && i % 7 != 0)
                {
                    System.Console.Write(" {0}", i);
                }
            }
            
            System.Console.WriteLine();
        }
    }
}