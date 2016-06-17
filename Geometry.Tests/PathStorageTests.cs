namespace Geometry.Tests
{
    using System;

    public class PathStorageTests
    {
        private const int NumberOfPoints = 10;
        private const string PathFileName = "test-path-file-name.txt";

        public void WriteAndReadPathTest()
        {
            var path = new Path();

            for (int i = 1; i < NumberOfPoints; ++i)
            {
                var point = new Point3D
                {
                    X = i,
                    Y = i,
                    Z = i
                };

                path.SequenceOfPoints.Add(point);
            }

            Console.WriteLine(string.Join(", ", path.SequenceOfPoints));
            Console.WriteLine();

            PathStorage.SavePathToFile(PathFileName, path);

            var newPath = PathStorage.LoadPathFromFile(PathFileName);
            Console.WriteLine(string.Join(", ", newPath.SequenceOfPoints));
        }
    }
}
