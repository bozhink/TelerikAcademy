namespace ConsoleApplication1
{
    using System;

    public class Program
    {
        // even -> even number - you will multiply the result by 376439
        //  odd number - you will divide the result by 7

        public static void Main(string[] args)
        {
            int t = int.Parse(Console.ReadLine()); // number of trees
            int b = int.Parse(Console.ReadLine()); // number of branches per tree
            int s = int.Parse(Console.ReadLine()); // number of squirrels per branch
            int n = int.Parse(Console.ReadLine()); // number of tails

            double numberOfTails = (double)t * (double)b * (double)s * (double)n;

            if (numberOfTails % 2 == 0)
            {
                double result = numberOfTails * 376439;
                Console.WriteLine(result.ToString("f3"));
            }
            else
            {
                double result = numberOfTails / 7.0;
                Console.WriteLine(result.ToString("f3"));
            }
        }
    }
}