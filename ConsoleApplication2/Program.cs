namespace ConsoleApplication2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        public static void Main(string[] args)
        {
            int numberOfCars = int.Parse(Console.ReadLine()); // Number of cars
            double[] speeds = new double[numberOfCars];
            for (int i = 0; i < numberOfCars; ++i)
            {
                speeds[i] = double.Parse(Console.ReadLine());
            }
        }
    }
}