namespace NumbersFrom1ToN
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
                System.Console.Write(" {0}", i);
            }
            
            System.Console.WriteLine();
        }
    }
}