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

            //Console.WriteLine(string.Join(" ", speeds));

            int[] clusterLenghts = new int[speeds.Length];
            int[] clusterSums = new int[speeds.Length];

            int left = 0, right = 0, length = 0, currentCluster = 0;
            for (int i = 0; i < numberOfCars; ++i)
            {
                if (speeds[i] >= speeds[i + 1])
                {
                    // Generate cluster
                    right = i;
                    length = right - left + 1;

                    //Console.WriteLine("{0} {1} {2}", left, right, length);

                    clusterLenghts[currentCluster] = length;
                    clusterSums[currentCluster] = ClusterSum(speeds, left, right);

                    currentCluster++;

                    left = i + 1;
                }
            }

            //for (int i = 0; i < speeds.Length; ++i)
            //{
            //    Console.WriteLine("{0} {1}", clusterLenghts[i], clusterSums[i]);
            //}

            int maximalLength = clusterLenghts[0];
            int position = 0;
            for (int i = 1; i < speeds.Length; ++i)
            {
                if (maximalLength < clusterLenghts[i])
                {
                    maximalLength = clusterLenghts[i];
                    position = i;
                }
                else if (maximalLength == clusterLenghts[i])
                {
                    if (clusterSums[i] > clusterSums[position])
                    {
                        maximalLength = clusterLenghts[i];
                        position = i;
                    }
                }

                //Console.WriteLine("{0} {1}", clusterLenghts[i], clusterSums[i]);

            }

            Console.WriteLine(clusterSums[position]);
        }

        public static int ClusterSum(int[] lane, int left, int right)
        {
            int result = 0;
            for (int j = left; j <= right; ++j)
            {
                result += lane[j];
            }

            return result;
        }
    }
}