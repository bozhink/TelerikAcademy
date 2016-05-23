namespace SortingArray
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] array = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            SortAscending(array);

            Console.WriteLine(string.Join(" ", array));
        }

        public static int GetExtremalElementIndex<T>(T[] array, int startIndex, Func<T, T, bool> comparer)
        {
            int n = array.Length;
            if (startIndex >= n)
            {
                throw new ArgumentException();
            }

            int index = startIndex;
            for (int i = startIndex + 1; i < n; ++i)
            {
                if (comparer.Invoke(array[i], array[index]))
                {
                    index = i;
                }
            }

            return index;
        }

        public static void SortAscending(int[] array)
        {
            for (int i = 0; i < array.Length; ++i)
            {
                int index = GetExtremalElementIndex(array, i, (x, y) => x < y);
                if (i != index)
                {
                    Swap(array, i, index);
                }
            }
        }

        public static void SortDescending(int[] array)
        {
            for (int i = 0; i < array.Length; ++i)
            {
                int index = GetExtremalElementIndex(array, i, (x, y) => x > y);
                if (i != index)
                {
                    Swap(array, i, index);
                }
            }
        }

        public static void Swap(int[] array, int i, int j)
        {
            var swap = array[i];
            array[i] = array[j];
            array[j] = swap;
        }
    }
}
