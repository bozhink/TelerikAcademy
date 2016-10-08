namespace Methods
{
    using System;

    public class Methods
    {
        public static void Main()
        {
            Console.WriteLine(Geometry.CalcTriangleArea(3, 4, 5));
            
            Console.WriteLine(Digit.ToString(5));
            
            Console.WriteLine(Statistics.FindMax(5, -1, 3, 2, 14, 2, 3));

            Printer.PrintAsNumber(1.3, Printer.Format.FixedPoint);
            Printer.PrintAsNumber(0.75, Printer.Format.Percent);
            Printer.PrintAsNumber(2.30, Printer.Format.FixedWidth);

            Geometry.Point point1 = new Geometry.Point(3.0, -1.0);
            Geometry.Point point2 = new Geometry.Point(3.0, 2.5);
            Geometry.Line line = new Geometry.Line(point1, point2);
            Console.WriteLine(line.GetLength());
            Console.WriteLine("Horizontal? " + line.IsHorizontal);
            Console.WriteLine("Vertical? " + line.IsVertical);

            Student peter = new Student("Peter", "Ivanov", "From Sofia, born at 17.03.1992");
            Student stella = new Student("Stella", "Markova", "From Vidin, gamer, high results, born at 03.11.1993");

            Console.WriteLine(
                "{0} older than {1} -> {2}",
                peter.FirstName,
                stella.FirstName,
                peter.IsOlderThan(stella));
        }
    }
}
