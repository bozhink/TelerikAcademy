namespace IntegerSum
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            Console.WriteLine(SumIntegers(array));
        }

        public static int SumIntegers(params int[] array)
        {
            int sum = 0;
            foreach (var item in array)
            {
                sum += item;
            }

            return sum;
        }
    }
}