namespace TriangleSurfaceByThreeSides
{
    using System;

    public class Program
    {
        public static void Main()
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine());

            double p = 0.5 * (a + b + c);

            double area = Math.Sqrt(p * (p - a) * (p - b) * (p - c));

            Console.WriteLine("{0:F2}", area);
        }
    }
}
