namespace CompareCharArrays
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            string input1 = Console.ReadLine();
            string input2 = Console.ReadLine();

            char[] array1 = input1.ToCharArray();
            char[] array2 = input2.ToCharArray();

            int length = Math.Min(array1.Length, array2.Length);

            for (int i = 0; i < length; ++i)
            {
                if (array1[i] > array2[i])
                {
                    Console.WriteLine(">");
                    return;
                }

                if (array1[i] < array2[i])
                {
                    Console.WriteLine("<");
                    return;
                }
            }

            if (array1.Length > array2.Length)
            {
                Console.WriteLine(">");
                return;
            }

            if (array1.Length < array2.Length)
            {
                Console.WriteLine("<");
                return;
            }

            Console.WriteLine("=");
        }
    }
}