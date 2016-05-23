namespace PrintLongSequence
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            const int NumberOfItemsToPrint = 1000;
            const int InitialNumber = 2;

            int sign = 1;
            int currentNumber = InitialNumber;
            for (int i = 0; i < NumberOfItemsToPrint; ++i)
            {
                Console.WriteLine(sign * currentNumber);
                ++currentNumber;
                sign *= -1;
            }
        }
    }
}