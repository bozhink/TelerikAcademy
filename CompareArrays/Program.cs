namespace CompareArrays
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] array1 = new int[n];

            for (int i = 0; i < n; ++i)
            {
                array1[i] = int.Parse(Console.ReadLine());
            }

            int[] array2 = new int[n];

            for (int i = 0; i < n; ++i)
            {
                array2[i] = int.Parse(Console.ReadLine());
            }

            bool areEqual = true;
            for (int i = 0; i < n; ++i)
            {
                if (array1[i] != array2[i])
                {
                    areEqual = false;
                    break;
                }
            }

            switch (areEqual)
            {
                case true:
                    Console.WriteLine("Equal");
                    break;

                default:
                    Console.WriteLine("Not equal");
                    break;
            }
        }
    }
}