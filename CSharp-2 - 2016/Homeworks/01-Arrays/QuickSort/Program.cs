namespace QuickSort
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

            QuickSort(array, 0, array.Length - 1);

            for (int i = 0; i < n; ++i)
            {
                Console.WriteLine(array[i]);
            }
        }

        public static void QuickSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int q = Partition(array, left, right);
                QuickSort(array, left, q - 1);
                QuickSort(array, q + 1, right);
            }
        }

        private static int Partition(int[] array, int left, int right)
        {
            int pivot = array[right];

            int i = left;
            for (int j = left; j < right; j++)
            {
                if (array[j] <= pivot)
                {
                    int swap = array[j];
                    array[j] = array[i];
                    array[i] = swap;
                    i++;
                }
            }

            array[right] = array[i];
            array[i] = pivot;

            return i;
        }
    }
}
