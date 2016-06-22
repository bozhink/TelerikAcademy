namespace Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class IEnumerableExtensions
    {
        public static decimal Sum<T>(this IEnumerable<T> collection)
            where T : IConvertible
        {
            var decimalCollection = collection
                .Select(x => Convert.ToDecimal(x));

            decimal result = 0;

            foreach (var number in decimalCollection)
            {
                result += number;
            }

            return result;
        }

        public static decimal Product<T>(this IEnumerable<T> collection)
            where T : IConvertible
        {
            var decimalCollection = collection
                .Select(x => Convert.ToDecimal(x));

            decimal result = 1;

            foreach (var number in decimalCollection)
            {
                result *= number;
            }

            return result;
        }

        public static decimal Min<T>(this IEnumerable<T> collection)
            where T : IConvertible
        {
            var decimalCollection = collection
                .Select(x => Convert.ToDecimal(x));

            decimal result = decimal.MaxValue;

            foreach (var number in decimalCollection)
            {
                if (number < result)
                {
                    result = number;
                }
            }

            return result;
        }

        public static decimal Max<T>(this IEnumerable<T> collection)
            where T : IConvertible
        {
            var decimalCollection = collection
                .Select(x => Convert.ToDecimal(x));

            decimal result = decimal.MinValue;

            foreach (var number in decimalCollection)
            {
                if (number > result)
                {
                    result = number;
                }
            }

            return result;
        }

        public static decimal Average<T>(this IEnumerable<T> collection)
            where T : IConvertible
        {
            var decimalCollection = collection
                .Select(x => Convert.ToDecimal(x));

            decimal sum = 0;

            foreach (var number in decimalCollection)
            {
                sum += number;
            }

            return sum / decimalCollection.Count();
        }
    }
}
