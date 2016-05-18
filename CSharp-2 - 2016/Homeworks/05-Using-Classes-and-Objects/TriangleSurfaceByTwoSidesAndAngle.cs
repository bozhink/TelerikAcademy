namespace TriangleSurfaceByTwoSidesAndAngle
{
    using System;

    public class Program
    {
        public static void Main()
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double angle = Math.PI / 180.0 * double.Parse(Console.ReadLine());

            double altitude = a * Math.Sin(angle);
            double area = 0.5  * altitude * b;

            Console.WriteLine("{0:F2}", area);
        }
    }
}
