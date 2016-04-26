namespace ConsoleApplication5
{
    using System;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int numberOfItems = int.Parse(Console.ReadLine());
            int[] items = new int[numberOfItems];
            for (int i = 0; i < numberOfItems; ++i)
            {
                items[i] = int.Parse(Console.ReadLine());
            }

            string keyCode = Convert.ToString(key, 2).TrimStart('0');
            Regex re = new Regex(keyCode, RegexOptions.RightToLeft);
            string replacement = new string('0', keyCode.Length);

            int lengthOfKeyCode = keyCode.Length;
            foreach (var item in items)
            {
                string code = Convert.ToString(item, 2);
                //Console.WriteLine(code);

                string resultCode = re.Replace(code, replacement);
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