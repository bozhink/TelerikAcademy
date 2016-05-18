namespace HexadecumalToDecimal
{
    using System;
    using System.Text;
    
    public class Program
    {
        private const int NumericalBase = 16;
        private const string Alphabet = "0123456789ABCDEF";
        
        public static void Main(string[] args)
        {
            string n = Console.ReadLine();
            Console.WriteLine(HexadecumalToDecimal(n));
        }
        
        public static ulong HexadecumalToDecimal(string n)
        {
            ulong result = 0;
            ulong multiplier = 1;
            
            for (int i = n.Length - 1; i >= 0; --i)
            {
                char digit = n[i];
                result += multiplier * (ulong)Alphabet.IndexOf(digit);
                multiplier *= NumericalBase;
            }
            
            return result;
        }
    }
}
