namespace AppearanceCount
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

            int x = int.Parse(Console.ReadLine());

            Console.WriteLine(CountAppearance(x, array));
        }

        public static int CountAppearance(int x, int[] array)
        {
            int count = 0;
            for (int i = 0; i < array.Length; ++i)
            {
                if (array[i] == x)
                {
                    ++count;
                }
            }

            return count;
        }
    }
}