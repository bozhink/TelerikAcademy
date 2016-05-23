namespace FirstLargerThanNeighbours
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int[] array = input.Select(i => int.Parse(i)).ToArray();

            for (int i = 0; i < n; ++i)
            {
                bool larger = IsLargerThanNeighbours(array, i - 1, i, i + 1);

                if (larger)
                {
                    Console.WriteLine(i);
                    return;
                }
            }

            Console.WriteLine(-1);
        }

        public static bool IsLargerThanNeighbours(int[] array, int positionLeft, int position, int positionRight)
        {
            int n = array.Length;
            if (positionLeft < 0 || positionRight >= n || n <= position || position < 0)
            {
                return false;
            }

            if (array[positionLeft] < array[position] && array[position] > array[positionRight])
            {
                return true;
            }

            return false;
        }
    }
}