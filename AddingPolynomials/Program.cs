namespace AddingPolynomials
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] coefficientsOfFirstPolynomial = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] coefficientsOfSecondPolynomial = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var result = Add(coefficientsOfFirstPolynomial, coefficientsOfSecondPolynomial);
            Console.WriteLine(string.Join(" ", result));
        }

        public static int[] Add(int[] array1, int[] array2)
        {
            if (array1.Length < array2.Length)
            {
                return Add(array2, array1);
            }
            else
            {
                int[] result = new int[array1.Length];

                for (int i = 0; i < array2.Length; ++i)
                {
                    result[i] = array1[i] + array2[i];
                }

                for (int i = array2.Length; i < array1.Length; ++i)
                {
                    result[i] = array1[i];
                }

                return result;
            }
        }
    }
}
