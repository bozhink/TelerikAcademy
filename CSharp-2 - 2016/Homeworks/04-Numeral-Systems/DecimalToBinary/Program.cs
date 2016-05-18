namespace DecimalToBinary
{
    using System;
    using System.Text;
    
    public class Program
    {
        private const int NumericalBase = 2;
        
        public static void Main(string[] args)
        {
            ulong n = ulong.Parse(Console.ReadLine());
            Console.WriteLine(DecimalToBinary(n));
        }
        
        public static string DecimalToBinary(ulong n)
        {
            ulong x = n;
            var stringBuilder = new StringBuilder();

            while (x > 0)
            {
                stringBuilder.Insert(0, (x % NumericalBase).ToString());
                x /= NumericalBase;
            }
            
            return stringBuilder.ToString();
        }
    }
}
