namespace Calculate
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double x = double.Parse(Console.ReadLine());

            double partial = 1.0;
            double s = partial;
            for (int i = 1; i <= n; ++i)
            {
                partial *= i / x;
                s += partial;
            }

            Console.WriteLine(s.ToString("f5"));
        }
    }
}