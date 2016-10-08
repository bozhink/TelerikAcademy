namespace Abstraction
{
    using System;

    public abstract class Figure : IFigure
    {
        private double width;
        private double height;
        private double radius;
        
        public Figure(double radius)
        {
            this.Radius = radius;
        }

        public Figure(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public virtual double Width
        {
            get
            {
                return this.width;
            }

            set
            {
                if (double.IsInfinity(value) || double.IsNaN(value))
                {
                    throw new Exception("Invalid value for Width.");
                }

                this.width = value;
            }
        }

        public virtual double Height
        {
            get
            {
                return this.height;
            }

            set
            {
                if (double.IsInfinity(value) || double.IsNaN(value))
                {
                    throw new Exception("Invalid value for Height.");
                }

                this.height = value;
            }
        }

        public virtual double Radius
        {
            get
            {
                return this.radius;
            }

            set
            {
                if (double.IsInfinity(value) || double.IsNaN(value))
                {
                    throw new Exception("Invalid value for Radius.");
                }

                this.radius = value;
            }
        }

        public abstract double CalcPerimeter();

        public abstract double CalcSurface();
    }
}
