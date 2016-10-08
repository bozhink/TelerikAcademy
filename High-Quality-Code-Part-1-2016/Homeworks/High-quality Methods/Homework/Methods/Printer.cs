namespace Methods
{
    using System;

    public class Printer
    {
        public enum Format
        {
            FixedPoint,
            Percent,
            FixedWidth
        }

        public static void PrintAsNumber(object number, Format format)
        {
            switch (format)
            {
                case Format.FixedPoint:
                    Console.WriteLine("{0:f2}", number);
                    break;
                case Format.Percent:
                    Console.WriteLine("{0:p0}", number);
                    break;
                case Format.FixedWidth:
                    Console.WriteLine("{0,8}", number);
                    break;
            }
        }
    }
}
