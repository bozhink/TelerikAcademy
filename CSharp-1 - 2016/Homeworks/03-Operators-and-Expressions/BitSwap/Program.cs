namespace BitSwap
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            uint n = uint.Parse(Console.ReadLine());
            byte p = byte.Parse(Console.ReadLine());
            byte q = byte.Parse(Console.ReadLine());
            byte k = byte.Parse(Console.ReadLine());

            for (byte i = 0; i < k; ++i)
            {
                n = BitSwap(n, (byte)(p + i), (byte)(q + i));
            }

            Console.WriteLine(n);
        }

        public static uint BitSwap(uint number, byte position1, byte position2)
        {
            uint bit1 = (number >> position1) & 1u;
            uint bit2 = (number >> position2) & 1u;

            uint result = ChangeBit(number, (byte)bit1, position2);
            result = ChangeBit(result, (byte)bit2, position1);

            return result;
        }

        public static uint ChangeBit(uint number, byte value, byte position)
        {
            switch (value)
            {
                case 0:
                    return number & (~Mask(position));

                case 1:
                    return number | Mask(position);

                default:
                    throw new InvalidOperationException();
            }
        }

        public static uint Mask(byte position)
        {
            uint mask = 1u;
            mask <<= position;
            return mask;
        }
    }
}