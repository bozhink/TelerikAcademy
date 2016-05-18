namespace IntegerClculations
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Console.WriteLine(Minimum(array));
            Console.WriteLine(Maximum(array));
            Console.WriteLine("{0:F2}", Average(array));
            Console.WriteLine(Sum(array));
            Console.WriteLine(Product(array));
        }

        public static int Minimum(params int[] args)
        {
            int min = int.MaxValue;
            for (int i = 0; i < args.Length; ++i)
            {
                if (args[i] < min)
                {
                    min = args[i];
                }
            }

            return min;
        }

        public static int Maximum(params int[] args)
        {
            int max = int.MinValue;
            for (int i = 0; i < args.Length; ++i)
            {
                if (args[i] > max)
                {
                    max = args[i];
                }
            }

            return max;
        }

        public static long Sum(int[] args)
        {
            long sum = 0;
            for (int i = 0; i < args.Length; ++i)
            {
                sum += args[i];
            }

            return sum;
        }

        public static long Product(int[] args)
        {
            long product = 1;
            for (int i = 0; i < args.Length; ++i)
            {
                product *= args[i];
            }

            return product;
        }

        public static double Average(int[] args)
        {
            double sum = 0.0;
            for (int i = 0; i < args.Length; ++i)
            {
                sum += args[i];
            }

            return sum / args.Length;
        }
    }
}
