namespace ConsoleApplication5
{
    using System;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main(string[] args)
        {
            uint key = uint.Parse(Console.ReadLine());
            int numberOfItems = int.Parse(Console.ReadLine());
            uint[] items = new uint[numberOfItems];
            for (int i = 0; i < numberOfItems; ++i)
            {
                items[i] = uint.Parse(Console.ReadLine());
            }

            string keyCode = Convert.ToString(key, 2).TrimStart('0');
            int lengthOfKeyCode = keyCode.Length;
            foreach (var item in items)
            {
                string code = Convert.ToString(item, 2);
                int codeLength = code.Length;

                //Console.WriteLine(code);

                Regex re = new Regex(keyCode, RegexOptions.RightToLeft);

                string resultCode = re.Replace(code, new string('0', lengthOfKeyCode));
                //Console.WriteLine(resultCode);
                Console.WriteLine(BinaryToDecimal(resultCode));
            }
        }

        public static uint BinaryToDecimal(string code)
        {
            long result = 0;
            long multiplier = 1;
            for (int i = code.Length - 1; i >= 0; --i)
            {
                result += (code[i] == '0' ? 0 : 1) * multiplier;
                multiplier *= 2;
            }

            return (uint)result;
        }
    }
}