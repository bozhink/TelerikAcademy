namespace CohesionAndCoupling
{
    using System;

    public class Geometry
    {
        private double width;
        private double height;
        private double depth;

        public Geometry(double width, double height, double depth)
        {
            this.Width = width;
            this.Height = height;
            this.Depth = depth;
        }

        public double Width
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

        public double Depth
        {
            get
            {
                return this.depth;
            }

            set
            {
                if (double.IsInfinity(value) || double.IsNaN(value))
                {
                    throw new Exception("Invalid value for Depth.");
                }

                this.depth = value;
            }
        }

        public static double CalcDistance2D(double x1, double y1, double x2, double y2)
        {
            double distance = 0.0;
            try
            {
                distance = Math.Sqrt(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)));
            }
            catch (Exception)
            {
                throw new Exception("Cannot calculate Distance2D.");
            }

            if (double.IsInfinity(distance))
            {
                throw new Exception("Distance2D is infinity.");
            }

            if (double.IsNaN(distance))
            {
                throw new Exception("Distance2D is NaN");
            }

            return distance;
        }

        public static double CalcDistance3D(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            double distance = 0.0;
            try
            {
                distance = Math.Sqrt(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)) + ((z2 - z1) * (z2 - z1)));
            }
            catch (Exception)
            {
                throw new Exception("Cannot calculate Distance3D.");
            }

            if (double.IsInfinity(distance))
            {
                throw new Exception("Distance3D is infinity.");
            }

            if (double.IsNaN(distance))
            {
                throw new Exception("Distance3D is NaN");
            }

            return distance;
        }

        public double CalcVolume()
        {
            double volume = 0.0;
            try
            {
                volume = this.Width * this.Height * this.Depth;
            }
            catch (Exception)
            {
                throw new Exception("Cannot calculate Volume.");
            }

            if (double.IsInfinity(volume))
            {
                throw new Exception("Volume is infinity.");
            }

            if (double.IsNaN(volume))
            {
                throw new Exception("Volume is NaN");
            }

            return volume;
        }

        public double CalcDiagonalXYZ()
        {
            double distance = 0.0;
            try
            {
                distance = CalcDistance3D(0, 0, 0, this.Width, this.Height, this.Depth);
            }
            catch (Exception)
            {
                throw new Exception("Cannot calculate DiagonalXYZ.");
            }

            if (double.IsInfinity(distance))
            {
                throw new Exception("DiagonalXYZ is infinity.");
            }

            if (double.IsNaN(distance))
            {
                throw new Exception("DiagonalXYZ is NaN");
            }

            return distance;
        }

        public double CalcDiagonalXY()
        {
            double distance = 0.0;
            try
            {
                distance = CalcDistance2D(0, 0, this.Width, this.Height);
            }
            catch (Exception)
            {
                throw new Exception("Cannot calculate DiagonalXY.");
            }

            if (double.IsInfinity(distance))
            {
                throw new Exception("DiagonalXY is infinity.");
            }

            if (double.IsNaN(distance))
            {
                throw new Exception("DiagonalXY is NaN");
            }

            return distance;
        }

        public double CalcDiagonalXZ()
        {
            double distance = 0.0;
            try
            {
                distance = CalcDistance2D(0, 0, this.Width, this.Depth);
            }
            catch (Exception)
            {
                throw new Exception("Cannot calculate DiagonalXZ.");
            }

            if (double.IsInfinity(distance))
            {
                throw new Exception("DiagonalXZ is infinity.");
            }

            if (double.IsNaN(distance))
            {
                throw new Exception("DiagonalXZ is NaN");
            }

            return distance;
        }

        public double CalcDiagonalYZ()
        {
            double distance = 0.0;
            try
            {
                distance = CalcDistance2D(0, 0, this.Height, this.Depth);
            }
            catch (Exception)
            {
                throw new Exception("Cannot calculate DiagonalYZ.");
            }

            if (double.IsInfinity(distance))
            {
                throw new Exception("DiagonalYZ is infinity.");
            }

            if (double.IsNaN(distance))
            {
                throw new Exception("DiagonalYZ is NaN");
            }

            return distance;
        }
    }
}
