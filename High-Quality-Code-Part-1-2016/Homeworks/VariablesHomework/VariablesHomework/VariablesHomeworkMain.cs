namespace VariablesHomework
{
    using System;

    /// <summary>
    /// High Quality Code
    /// Variables, Data, Expressions and Constants Homework
    /// </summary>
    public static class VariablesHomework
    {
        /// <summary>
        /// Some tests over homework tasks.
        /// </summary>
        /// <param name="args">Console parameters. Not used here.</param>
        public static void Main(string[] args)
        {
            const double PiDividedBy2 = 3.14159265 / 2.0;
            double width = 1.0;
            double height = 1.41;
            Size testSizeObject = new Size(width, height);
            Size rotatedSizeObject = Size.GetRotatedSize(testSizeObject, PiDividedBy2);

            Console.WriteLine(
                "Initial object: ({0}, {1})\n",
                testSizeObject.Width,
                testSizeObject.Height);
            Console.WriteLine(
                "Rotated object: ({0}, {1})\n",
                rotatedSizeObject.Width,
                rotatedSizeObject.Height);

            Statistics statistics = new Statistics();
            double[] dataArray = new double[3] { 1.2, 5.6, 3.4 };
            statistics.PrintStatistics(dataArray, dataArray.Length);
        }
    }
}
