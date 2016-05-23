namespace SystemToSystem
{
    using System;
    using System.Text;
    
    public class Program
    {
        private const string BinAlphabet = "01";
        private const string HexAlphabet = "0123456789ABCDEF";
        
        public static void Main(string[] args)
        {
            int s = int.Parse(Console.ReadLine());
            string n = Console.ReadLine();
            int d = int.Parse(Console.ReadLine());

            Console.WriteLine(SystemToSystem(n, HexAlphabet.Substring(0, s), HexAlphabet.Substring(0, d)));
        }
        
        public static string SystemToSystem(string n, string sourceAlphabet, string resultAplhabet)
        {
             ulong dec = SystemToDecimal(n, sourceAlphabet);
             return DecimalToSystem(dec, resultAplhabet);
        }
        
        public static string DecimalToSystem(ulong n, string alphabet)
        {
            ulong numericalBase = (ulong)alphabet.Length;
            
            ulong x = n;
            var stringBuilder = new StringBuilder();
            
            while (x > 0)
            {
                stringBuilder.Insert(0, alphabet[(int)(x % numericalBase)]);
                x /= numericalBase;
            }
            
            return stringBuilder.ToString();
        }
        
        public static ulong SystemToDecimal(string n, string alphabet)
        {
            ulong numericalBase = (ulong)alphabet.Length;
            
            ulong result = 0;
            ulong multiplier = 1;
            
            for (int i = n.Length - 1; i >= 0; --i)
            {
                char digit = n[i];
                result += multiplier * (ulong)alphabet.IndexOf(digit);
                multiplier *= numericalBase;
            }
            
            return result;
        }
    }
}
