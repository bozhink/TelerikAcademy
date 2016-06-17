namespace Geometry
{
    using System;
    using System.Collections.Generic;

    public class Path
    {
        public Path()
        {
            this.SequenceOfPoints = new List<Point3D>();
        }

        public Path(params Point3D[] points)
        {
            if (points == null)
            {
                throw new ArgumentNullException(nameof(points));
            }

            if (points.Length < 1)
            {
                throw new ArgumentException(nameof(points));
            }

            this.SequenceOfPoints = new List<Point3D>(points);
        }

        public ICollection<Point3D> SequenceOfPoints { get; private set; }
    }
}
