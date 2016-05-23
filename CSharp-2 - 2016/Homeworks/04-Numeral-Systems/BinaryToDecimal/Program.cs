namespace BinaryToDecimal
{
    using System;
    using System.Text;
    
    public class Program
    {
        private const int NumericalBase = 2;
        
        public static void Main(string[] args)
        {
            string n = Console.ReadLine();
            Console.WriteLine(BinaryToDecimal(n));
        }
        
        public static ulong BinaryToDecimal(string n)
        {
            ulong result = 0;
            ulong multiplier = 1;
            
            for (int i = n.Length - 1; i >= 0; --i)
            {
                string digit = n[i].ToString();
                result += multiplier * ulong.Parse(digit);
                multiplier *= NumericalBase;
            }
            
            return result;
        }
    }
}
