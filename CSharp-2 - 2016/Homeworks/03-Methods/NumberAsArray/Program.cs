namespace NumberAsArray
{
    using System;
    using System.Linq;
    using System.Text;

    public class Program
    {
        private const int NumberBase = 10;

        public static void Main()
        {
            Console.ReadLine();
            byte[] firstArray = Console.ReadLine().Split(' ').Select(byte.Parse).ToArray();
            byte[] secondArray = Console.ReadLine().Split(' ').Select(byte.Parse).ToArray();

            string sum = SumArrays(firstArray, secondArray);
            Console.WriteLine(sum);
        }

        private static string SumArrays(byte[] firstArray, byte[] secondArray)
        {
            byte[] maxArray = firstArray;
            byte[] minArray = secondArray;

            if (firstArray.Length < secondArray.Length)
            {
                maxArray = secondArray;
                minArray = firstArray;
            }

            var result = new StringBuilder();
            int addition = 0;
            int sum = 0;

            int minLength = minArray.Length;
            for (int i = 0; i < minLength; ++i)
            {
                sum = minArray[i] + maxArray[i] + addition;
                addition = sum / NumberBase;
                sum = (sum + NumberBase) % NumberBase;
                result.Append(sum);
            }

            int maxLength = maxArray.Length;
            for (int i = minLength; i < maxLength; ++i)
            {
                sum = maxArray[i] + addition;
                addition = sum / NumberBase;
                sum = (sum + NumberBase) % NumberBase;
                result.Append(sum);
            }

            if (addition > 0)
            {
                result.Append(addition);
            }

            char[] reversed = result.ToString().ToCharArray();
            result.Clear();

            for (int i = 0; i < reversed.Length; ++i)
            {
                result.Append(reversed[i]);
                result.Append(" ");
            }

            return result.ToString();
        }
    }
}