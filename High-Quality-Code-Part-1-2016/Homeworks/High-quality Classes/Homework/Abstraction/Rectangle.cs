namespace Abstraction
{
    using System;

    public class Rectangle : Figure
    {
        public Rectangle()
            : base(0, 0)
        {
        }

        public Rectangle(double width, double height)
            : base(width, height)
        {
        }

        public override double Radius
        {
            get
            {
                throw new NotImplementedException("Rectangle does not have Radius");
            }
            
            set
            {
                throw new NotImplementedException("Rectangle does not have Radius");
            }
        }

        public override double CalcPerimeter()
        {
            double perimeter = 0.0;
            try
            {
                perimeter = 2 * (this.Width + this.Height);
            }
            catch (Exception)
            {
                throw new Exception("Cannot calculate rectangle's perimeter.");
            }

            if (double.IsInfinity(perimeter))
            {
                throw new Exception("Rectangle's perimeter is infinity.");
            }

            if (double.IsNaN(perimeter))
            {
                throw new Exception("Rectangle's perimeter is NaN.");
            }

            return perimeter;
        }

        public override double CalcSurface()
        {
            double surface  = 0.0;
            try
            {
                surface = this.Width * this.Height;
            }
            catch (Exception)
            {
                throw new Exception("Cannot calculate rectangle's surface.");
            }

            if (double.IsInfinity(surface))
            {
                throw new Exception("Rectangle's surface is infinity.");
            }

            if (double.IsNaN(surface))
            {
                throw new Exception("Rectangle's surface is NaN.");
            }

            return surface;
        }
    }
}
