namespace LinqProblems
{
    using System;
    using System.Linq;

    public class DivisibleBy7And3
    {
        public void PrintDivisibleBy7And3Numbers(params int[] numbers)
        {
            if (numbers == null || numbers.Length < 1)
            {
                throw new ArgumentNullException(nameof(numbers));
            }

            numbers.Where(n => (n % 7 == 0) && (n % 3 == 0))
                .ToList()
                .ForEach(n => Console.WriteLine(n));
        }
    }
}
