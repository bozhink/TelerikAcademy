namespace RemoveElementsFromArray
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];
            var newArray = new List<int>();

            for (int i = 0; i < n; ++i)
            {
                array[i] = int.Parse(Console.ReadLine());
                newArray.Add(1);
            }

            int maximalSequence = 0;
            for (int j = 1; j < n; ++j)
            {
                for (int k = 0; k < j; ++k)
                {
                    if ((array[k] <= array[j]) && (newArray[j] < (newArray[k] + 1)))
                    {
                        newArray[j] = newArray[k] + 1;
                        if (maximalSequence < newArray[j])
                        {
                            maximalSequence = newArray[j];
                        }
                    }
                }
            }

            Console.WriteLine(n - maximalSequence);
        }
    }
}
