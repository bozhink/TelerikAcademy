namespace OddAndEvenProduct
{
    using System;
    using System.Linq;
    using System.Numerics;

    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var numbers = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray<int>();

            int length = numbers.Length;

            BigInteger oddProduct = 1;
            for (int i = 0; i < length; i += 2)
            {
                oddProduct *= numbers[i];
            }

            BigInteger evenProduct = 1;
            for (int i = 1; i < length; i += 2)
            {
                evenProduct *= numbers[i];
            }

            if (oddProduct == evenProduct)
            {
                Console.WriteLine("yes {0}", oddProduct);
            }
            else
            {
                Console.WriteLine("no {0} {1}", oddProduct, evenProduct);
            }
        }
    }
}