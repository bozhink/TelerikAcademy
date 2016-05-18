namespace TriangleSurfaceBySideAndAltitude
{
    using System;

    public class Program
    {
        public static void Main()
        {
            double sideLength = double.Parse(Console.ReadLine());
            double altitude = double.Parse(Console.ReadLine());

            var triangle = new Triangle(sideLength, altitude);
            Console.WriteLine("{0:F2}", triangle.CalculateArea());
        }
    }

    public class Triangle
    {
        private double sideLength;
        private double altitude;

        public Triangle()
        {
        }

        public Triangle(double sideLength, double altitude)
        {
            this.SideLength = sideLength;
            this.Altitude = altitude;
        }

        public double SideLength
        {
            get
            {
                return this.sideLength;
            }

            set
            {
                if (value < 0.0)
                {
                    throw new ArgumentException();
                }

                this.sideLength = value;
            }
        }

        private double Altitude
        {
            get
            {
                return this.altitude;
            }

            set
            {
                if (value < 0.0)
                {
                    throw new ArgumentException();
                }

                this.altitude = value;
            }
        }

        public double CalculateArea()
        {
            return 0.5 * this.SideLength * this.Altitude;
        }
    }
}
