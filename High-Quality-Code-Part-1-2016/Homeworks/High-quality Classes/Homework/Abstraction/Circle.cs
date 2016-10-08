namespace Abstraction
{
    using System;

    public class Circle : Figure
    {
        public Circle()
            : base(0)
        {
        }

        public Circle(double radius)
            : base(radius)
        {
        }

        public override double Width
        {
            get
            {
                throw new NotImplementedException("Circle does not have Width");
            }

            set
            {
                throw new NotImplementedException("Circle does not have Width");
            }
        }

        public override double Height
        {
            get
            {
                throw new NotImplementedException("Circle does not have Height");
            }

            set
            {
                throw new NotImplementedException("Circle does not have Height");
            }
        }

        public override double CalcPerimeter()
        {
            double perimeter = 0.0;
            try
            {
                perimeter = 2 * Math.PI * this.Radius;
            }
            catch (Exception)
            {
                throw new Exception("Cannot calculate circle's perimeter.");
            }

            if (double.IsInfinity(perimeter))
            {
                throw new Exception("Circle's perimeter is infinity.");
            }

            if (double.IsNaN(perimeter))
            {
                throw new Exception("Circle's perimeter is NaN.");
            }

            return perimeter;
        }

        public override double CalcSurface()
        {
            double surface = 0.0;
            try
            {
                surface = Math.PI * this.Radius * this.Radius;
            }
            catch (Exception)
            {
                throw new Exception("Cannot calculate circle's surface.");
            }

            if (double.IsInfinity(surface))
            {
                throw new Exception("Circle's surface is infinity.");
            }

            if (double.IsNaN(surface))
            {
                throw new Exception("Circle's surface is NaN.");
            }

            return surface;
        }
    }
}
