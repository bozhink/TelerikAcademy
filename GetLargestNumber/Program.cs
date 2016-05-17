namespace GetLargestNumber
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int max01 = GetMax(int.Parse(input[0]), int.Parse(input[1]));
            Console.WriteLine(GetMax(max01, int.Parse(input[2])));
        }

        public static int GetMax(int a, int b)
        {
            return Math.Max(a, b);
        }
    }
}