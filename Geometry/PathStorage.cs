namespace Geometry
{
    using System;
    using System.IO;
    using System.Linq;

    public static class PathStorage
    {
        private static Func<Point3D, string> PointToString => p => $"{p.X}\t{p.Y}\t{p.Z}";

        private static Func<string, Point3D> StringToPoint => s =>
        {
            var coordinates = s.Split('\t')?.Select(double.Parse)?.ToArray();
            if (coordinates == null || coordinates.Length < 3)
            {
                throw new ApplicationException("Invalid coordinate string.");
            }

            return new Point3D
            {
                X = coordinates[0],
                Y = coordinates[1],
                Z = coordinates[2]
            };
        };

        public static Path LoadPathFromFile(string fileName)
        {
            var lines = File.ReadAllLines(fileName);
            var points = lines.Select(StringToPoint).ToArray();

            return new Path(points);
        }

        public static void SavePathToFile(string fileName, Path path)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentNullException(nameof(fileName));
            }

            if (path == null)
            {
                throw new ArgumentNullException(nameof(path));
            }

            if (path.SequenceOfPoints.Count < 1)
            {
                throw new ArgumentException(nameof(path));
            }

            var lines = path.SequenceOfPoints.Select(PointToString).ToArray();
            File.WriteAllLines(fileName, lines);
        }
    }
}
