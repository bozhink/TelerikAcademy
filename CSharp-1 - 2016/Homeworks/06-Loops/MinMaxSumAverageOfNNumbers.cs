namespace MinMaxSumAverageOfNNumbers
{
    using System;

    public class Program 
    {
        public static void Main() 
        {
            int n = int.Parse(Console.ReadLine());
            double min = double.MaxValue;
            double max = double.MinValue;
            double sum = 0.0;
            
            for (int i = 0; i < n; ++i) 
            {
                double a = double.Parse(Console.ReadLine());
                
                if (a < min)
                {
                    min = a;
                }
                
                if (a > max)
                {
                    max = a;
                }
                
                sum += a;
            }

            System.Console.WriteLine("min={0:0.00}", min);
            System.Console.WriteLine("max={0:0.00}", max);
            System.Console.WriteLine("sum={0:0.00}", sum);
            System.Console.WriteLine("avg={0:0.00}", sum / n);
        }
    }
}