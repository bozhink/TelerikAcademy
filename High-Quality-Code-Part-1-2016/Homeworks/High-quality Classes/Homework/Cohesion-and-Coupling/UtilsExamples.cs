namespace CohesionAndCoupling
{
    using System;

    public class UtilsExamples
    {
        public static void Main()
        {
            Console.WriteLine(FileNameProcessor.GetFileExtension("example"));
            Console.WriteLine(FileNameProcessor.GetFileExtension("example.pdf"));
            Console.WriteLine(FileNameProcessor.GetFileExtension("example.new.pdf"));

            Console.WriteLine(FileNameProcessor.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileNameProcessor.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileNameProcessor.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine(
                "Distance in the 2D space = {0:f2}",
                Geometry.CalcDistance2D(1, -2, 3, 4));
            Console.WriteLine(
                "Distance in the 3D space = {0:f2}",
                Geometry.CalcDistance3D(5, 2, -1, 3, -6, 4));

            Geometry box = new Geometry(3, 4, 5);
            Console.WriteLine("Volume = {0:f2}", box.CalcVolume());
            Console.WriteLine("Diagonal XYZ = {0:f2}", box.CalcDiagonalXYZ());
            Console.WriteLine("Diagonal XY = {0:f2}", box.CalcDiagonalXY());
            Console.WriteLine("Diagonal XZ = {0:f2}", box.CalcDiagonalXZ());
            Console.WriteLine("Diagonal YZ = {0:f2}", box.CalcDiagonalYZ());
        }
    }
}
