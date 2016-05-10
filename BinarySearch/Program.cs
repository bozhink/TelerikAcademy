namespace BinarySearch
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] array = new int[n];
            for (int i = 0; i < n; ++i)
            {
                array[i] = int.Parse(Console.ReadLine());
            }

            int x = int.Parse(Console.ReadLine());

            Array.Sort(array);

            int index = BinarySearch(array, x);

            Console.WriteLine(index);
        }

        private static int BinarySearch(int[] array, int x)
        {
            int n = array.Length;

            int left = 0, rigth = n - 1;

            for (int i = 0; i < n; ++i)
            {
                if (left > rigth)
                {
                    return -1;
                }

                int middle = (left + rigth) / 2;

                if (array[middle] == x)
                {
                    return middle;
                }

                if (array[middle] < x)
                {
                    left = middle + 1;
                }
                else
                {
                    rigth = middle - 1;
                }
            }

            return -1;
        }
    }
}
