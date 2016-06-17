namespace Geometry
{
    public struct Point3D
    {
        private static readonly Point3D origin = new Point3D
        {
            X = 0.0,
            Y = 0.0,
            Z = 0.0
        };

        public static Point3D O => origin;

        public double X { get; set; }

        public double Y { get; set; }

        public double Z { get; set; }

        public override string ToString()
        {
            return $"({this.X}, {this.Y}, {this.Z})";
        }
    }
}
