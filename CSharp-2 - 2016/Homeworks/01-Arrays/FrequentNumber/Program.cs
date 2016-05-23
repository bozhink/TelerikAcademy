namespace FrequentNumber
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

            Array.Sort(array);

            int repeatingNumber = int.MinValue;
            int repeatedTimes = 1;
            int currentRepeatedTimes = 1;

            for (int i = 0; i < n; i++)
            {
                int currentNumber = array[i];
                for (int k = i + 1; k < n; k++)
                {
                    if (array[i] == array[k])
                    {
                        currentRepeatedTimes++;
                    }
                }

                if (currentRepeatedTimes > repeatedTimes)
                {
                    repeatingNumber = array[i];
                    repeatedTimes = currentRepeatedTimes;
                }

                currentRepeatedTimes = 1;
            }

            Console.WriteLine("{0} ({1} times)", repeatingNumber, repeatedTimes);
        }
    }
}
