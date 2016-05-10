namespace PrimeNumbers
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            uint n = uint.Parse(Console.ReadLine());
            bool result = false;
            if (!IsPrime(n))
            {
                do
                {
                    n--;
                    result = IsPrime(n);

                } while (!result);
            }

            Console.WriteLine(n);
        }

        private static bool IsPrime(uint n)
        {
            for (uint i = 2; i <= Math.Sqrt(n) + 1; ++i)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
