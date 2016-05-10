namespace SelectionSort
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double[] array = new double[n];
            for (int i = 0; i < n; ++i)
            {
                array[i] = double.Parse(Console.ReadLine());
            }

            SelectionSort(array);

            for (int i = 0; i < n; ++i)
            {
                Console.WriteLine(array[i]);
            }
        }

        public static void SelectionSort(double[] a)
        {
            int n = a.Length;
            for (int j = 0; j < n - 1; ++j)
            {
                int minimalIndex = j;
                for (int i = j + 1; i < n; ++i)
                {
                    if (a[i] < a[minimalIndex])
                    {
                        minimalIndex = i;
                    }
                }

                if (minimalIndex != j)
                {
                    Swap(a, j, minimalIndex);
                }
            }
        }

        private static void Swap(double[] a, int i, int j)
        {
            double swap = a[i];
            a[i] = a[j];
            a[j] = swap;
        }
    }
}
