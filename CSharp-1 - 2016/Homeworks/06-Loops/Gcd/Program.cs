namespace Gcd
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var inputs = input.Split(' ');

            int a = int.Parse(inputs[0]);
            int b = int.Parse(inputs[1]);

            Console.WriteLine(CalculateGcd(a, b));
        }

        public static int CalculateGcd(int a, int b)
        {
            int aa = a;
            int bb = b;
            while (bb != 0)
            {
                int tt = bb;
                bb = aa % bb;
                aa = tt;
            }

            return aa;
        }
    }
}