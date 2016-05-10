namespace MergeSort
{
    using System;

    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];
            for (int i = 0; i < n; ++i)
            {
                array[i] = int.Parse(Console.ReadLine());
            }

            MergeSort(array, 0, array.Length - 1);

            for (int i = 0; i < n; ++i)
            {
                Console.WriteLine(array[i]);
            }
        }

        public static void MergeSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;

                MergeSort(array, left, middle);
                MergeSort(array, middle + 1, right);

                int[] leftArray = new int[middle - left + 1];
                Array.Copy(array, left, leftArray, 0, middle - left + 1);

                int[] rightArray = new int[right - middle];
                Array.Copy(array, middle + 1, rightArray, 0, right - middle);

                int i = 0;
                int j = 0;
                for (int k = left; k < right + 1; k++)
                {
                    if (i == leftArray.Length)
                    {
                        array[k] = rightArray[j];
                        j++;
                    }
                    else if (j == rightArray.Length)
                    {
                        array[k] = leftArray[i];
                        i++;
                    }
                    else if (leftArray[i] <= rightArray[j])
                    {
                        array[k] = leftArray[i];
                        i++;
                    }
                    else
                    {
                        array[k] = rightArray[j];
                        j++;
                    }
                }
            }
        }
    }
}
