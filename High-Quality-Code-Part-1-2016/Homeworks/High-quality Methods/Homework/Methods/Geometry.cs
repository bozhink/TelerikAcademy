namespace Methods
{
    using System;

    public class Geometry
    {
        public static double CalcTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new Exception("Triangle's sides should be positive.");
            }

            if (((a + b) <= c) ||
                ((a + c) <= b) ||
                ((b + c) <= a))
            {
                throw new Exception("This is not a valid triangle.");
            }

            double halfSum = (a + b + c) / 2;
            double area = Math.Sqrt(halfSum * (halfSum - a) * (halfSum - b) * (halfSum - c));
            return area;
        }

        public class Point
        {
            private double x;
            private double y;

            public Point(double x, double y)
            {
                this.X = x;
                this.Y = y;
            }

            public double X
            {
                get
                {
                    return this.x;
                }

                set
                {
                    this.x = value;
                }
            }

            public double Y
            {
                get
                {
                    return this.y;
                }

                set
                {
                    this.y = value;
                }
            }
        }

        public class Line
        {
            private double tolerance = 1.0 / (double.MaxValue / 100.0);
            private Point startPoint;
            private Point endPoint;

            public Line(Point startPoint, Point endPoint)
            {
                this.startPoint = startPoint;
                this.endPoint = endPoint;
            }

            public bool IsVertical
            {
                get
                {
                    bool result = false;
                    try
                    {
                        result = Math.Abs(this.startPoint.X - this.endPoint.X) < this.tolerance;
                    }
                    catch (Exception)
                    {
                        result = false;
                    }

                    return result;
                }
            }

            public bool IsHorizontal
            {
                get
                {
                    bool result = false;
                    try
                    {
                        result = Math.Abs(this.startPoint.Y - this.endPoint.Y) < this.tolerance;
                    }
                    catch (Exception)
                    {
                        result = false;
                    }

                    return result;
                }
            }

            public double GetLength()
            {
                double differenceX = this.startPoint.X - this.endPoint.X;
                double differenceY = this.startPoint.Y - this.endPoint.Y;
                double length = Math.Sqrt((differenceX * differenceX) + (differenceY * differenceY));
                return length;
            }
        }
    }
}
