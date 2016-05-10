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

        private static int BinarySearch(int[] a, int x)
        {
            int n = a.Length;

            int l = 0, r = n - 1;

            for (int i = 0; i < n; ++i)
            {
                if (l > r)
                {
                    return -1;
                }

                int m = (l + r) / 2;

                if (a[m] == x)
                {
                    return m;
                }

                if (a[m] < x)
                {
                    l = m + 1;
                }
                else
                {
                    r = m - 1;
                }
            }

            return -1;
        }
    }
}
