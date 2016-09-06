namespace VariablesHomework
{
    using System;

    /// <summary>
    /// Task 2. Method PrintStatistics in C#
    /// Refactor the following code to apply variable usage and naming best practices
    /// </summary>
    public class Statistics
    {
        /// <summary>
        /// Prints statistical information about given data.
        /// </summary>
        /// <param name="dataArray">Data array which statistical information we need.</param>
        /// <param name="numberOfElements">Number of elements of the data array.</param>
        public void PrintStatistics(double[] dataArray, int numberOfElements)
        {
            // Validation
            if (dataArray.Length != numberOfElements)
            {
                throw new Exception("Inconsistent number of elements");
            }

            double maximalValue = GetMaximalValue(dataArray, numberOfElements);
            PrintMaximalValue(maximalValue);

            double minimalValue = GetMinimalValue(dataArray, numberOfElements);
            PrintMinimalValue(minimalValue);

            double mean = CalculateMeanValue(dataArray, numberOfElements);
            PrintMeanValue(mean);
        }

        /// <summary>
        /// Gets the value of the maximal element in a given array of data.
        /// </summary>
        /// <param name="dataArray">Data array which maximal element we are looking for.</param>
        /// <param name="numberOfElements">Number of elements of the data array.</param>
        /// <returns>The value of the maximal element in the data array.</returns>
        private static double GetMaximalValue(double[] dataArray, int numberOfElements)
        {
            double maximalValue = dataArray[0];
            for (int i = 1; i < numberOfElements; i++)
            {
                if (dataArray[i] > maximalValue)
                {
                    maximalValue = dataArray[i];
                }
            }

            return maximalValue;
        }

        /// <summary>
        /// Gets the value of the minimal element in a given array of data.
        /// </summary>
        /// <param name="dataArray">Data array which minimal element we are looking for.</param>
        /// <param name="numberOfElements">Number of elements of the data array.</param>
        /// <returns>The value of the minimal element in the data array.</returns>
        private static double GetMinimalValue(double[] dataArray, int numberOfElements)
        {
            double minimalValue = dataArray[0];
            for (int i = 1; i < numberOfElements; i++)
            {
                if (dataArray[i] < minimalValue)
                {
                    minimalValue = dataArray[i];
                }
            }

            return minimalValue;
        }

        /// <summary>
        /// Calculates the mean value of the elements in a given data array.
        /// </summary>
        /// <param name="dataArray">Data array which mean value are looking for.</param>
        /// <param name="numberOfElements">Number of elements of the data array.</param>
        /// <returns>The mean value of the elements in the data array.</returns>
        private static double CalculateMeanValue(double[] dataArray, int numberOfElements)
        {
            double sum = dataArray[0];
            for (int i = 1; i < numberOfElements; i++)
            {
                sum += dataArray[i];
            }

            double mean = sum / numberOfElements;
            return mean;
        }

        /// <summary>
        /// Prints to console a message for the maximal value.
        /// </summary>
        /// <param name="maximalValue">The maximal value to be printed.</param>
        private static void PrintMaximalValue(double maximalValue)
        {
            Console.WriteLine("Maximal value = {0}.\n", maximalValue);
        }

        /// <summary>
        /// Prints to console a message for the minimal value.
        /// </summary>
        /// <param name="minimalValue">The minimal value to be printed.</param>
        private static void PrintMinimalValue(double minimalValue)
        {
            Console.WriteLine("Minimal value = {0}.\n", minimalValue);
        }

        /// <summary>
        /// Prints to console a message for the mean value.
        /// </summary>
        /// <param name="meanValue">The mean value to be printed.</param>
        private static void PrintMeanValue(double meanValue)
        {
            Console.WriteLine("Mean value = {0}.\n", meanValue);
        }
    }
}
