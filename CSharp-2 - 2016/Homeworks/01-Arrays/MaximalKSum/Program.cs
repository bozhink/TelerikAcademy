namespace MaximalKSum
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            int[] array = new int[n];
            for (int i = 0; i < n; ++i)
            {
                array[i] = int.Parse(Console.ReadLine());
            }

            Array.Sort(array);

            long sum = 0;
            for (int i = n - k; i < n; ++i)
            {
                sum += array[i];
            }

            Console.WriteLine(sum);
        }
    }
}