namespace ConsoleApplication2
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            int numberOfCars = int.Parse(Console.ReadLine()); // Number of cars

            int[] speeds = new int[numberOfCars + 1];
            for (int i = 0; i < numberOfCars; ++i)
            {
                speeds[i] = int.Parse(Console.ReadLine());
            }

            int[] lane = new int[speeds.Length];
            for (int i = 0; i< speeds.Length; ++i)
            {
                lane[i] = speeds[i];
            }

            //Console.WriteLine(string.Join(" ", speeds));

            int left = 0, right = 0, length = 0;
            int maximalLenght = 0;
            long maximalSum = 0;
            for (int i = 0; i < numberOfCars; ++i)
            {
                if (lane[i] >= lane[i + 1])
                {
                    // Generate cluster
                    right = i;
                    length = right - left + 1;

                    long sum = ClusterSum(speeds, left, right);
                    //Console.WriteLine("{0} {1} {2}, {3}", left, right, length, sum);

                    if (maximalLenght < length)
                    {
                        maximalLenght = length;
                        maximalSum = sum;
                    }
                    else if (maximalLenght == length)
                    {
                        if (maximalSum < sum)
                        {
                            maximalSum = sum;
                        }
                    }

                    left = i + 1;
                }
                else
                {
                    lane[i + 1] = lane[i];
                }
            }

            Console.WriteLine(maximalSum);
        }

        public static long ClusterSum(int[] lane, int left, int right)
        {
            long result = 0;
            for (int j = left; j <= right; ++j)
            {
                result += lane[j];
            }

            return result;
        }
    }
}