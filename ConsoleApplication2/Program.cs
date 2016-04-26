namespace ConsoleApplication2
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main(string[] args)
        {
            int numberOfCars = int.Parse(Console.ReadLine()); // Number of cars
            int[] speeds = new int[numberOfCars];
            for (int i = 0; i < numberOfCars; ++i)
            {
                speeds[i] = int.Parse(Console.ReadLine());
            }

            int[] lane = new int[2 * speeds.Length];
            for (int i = 0; i < lane.Length; i += 2)
            {
                lane[i] = speeds[i / 2];
            }

            string laneString = string.Join(" ", lane);
            //Console.WriteLine(laneString);

            string oldLaneString = laneString;

            while (true)
            {
                Iterate(lane);
                laneString = string.Join(" ", lane);
                //Console.WriteLine(laneString);

                if (laneString == oldLaneString)
                {
                    break;
                }

                oldLaneString = laneString;
            }

            int[] clusterLenghts = new int[speeds.Length];
            int[] clusterSums = new int[speeds.Length];

            ICollection<KeyValuePair<int, int>> sums = new HashSet<KeyValuePair<int, int>>();

            int clusterLeft = 0;
            int clusterRight = 0;
            int clusterLenght = 0;

            int currentCluster = 0;
            for (int i = 1; i < lane.Length - 1; ++i)
            {
                if (lane[i] == 0)
                {
                    clusterRight = i - 1;
                    clusterLenght = clusterRight - clusterLeft + 1;

                    if (clusterLenght > 0)
                    {
                        clusterLenghts[currentCluster] = clusterLenght;

                        int clusterSum = ClusterSum(lane, clusterLeft, clusterRight);

                        clusterSums[currentCluster] = clusterSum;

                        currentCluster++;
                    }

                    //Console.WriteLine("{0} {1} {2}", clusterLeft, clusterRight, clusterLenght);

                    clusterLeft = i + 1;
                }
            }

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

        public static void Iterate(int[] lane)
        {
            for (int i = 1; i < lane.Length - 1; ++i)
            {
                if (lane[i] == 0)
                {
                    int left = lane[i - 1];
                    int right = lane[i + 1];
                    if (left < right)
                    {
                        lane[i] = lane[i + 1];
                        lane[i + 1] = 0;
                    }
                }
            }
        }
    }
}