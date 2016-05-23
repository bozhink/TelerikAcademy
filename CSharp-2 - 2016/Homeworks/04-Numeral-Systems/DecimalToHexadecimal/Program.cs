namespace DecimalToHexadecimal
{
    using System;
    using System.Text;
    
    public class Program
    {
        private const int NumericalBase = 16;
        private const string Alphabet = "0123456789ABCDEF";
        
        public static void Main(string[] args)
        {
            ulong n = ulong.Parse(Console.ReadLine());
            Console.WriteLine(DecimalToHexadecimal(n));
        }
        
        public static string DecimalToHexadecimal(ulong n)
        {
            ulong x = n;
            var stringBuilder = new StringBuilder();
            
            while (x > 0)
            {
                stringBuilder.Insert(0, Alphabet[(int)(x % NumericalBase)]);
                x /= NumericalBase;
            }
            
            return stringBuilder.ToString();
        }
    }
}
