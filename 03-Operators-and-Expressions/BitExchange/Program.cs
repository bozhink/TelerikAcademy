namespace BitExchange
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            uint n = uint.Parse(Console.ReadLine());

            uint bit3 = (n >> 3) & 1u;
            uint bit4 = (n >> 4) & 1u;
            uint bit5 = (n >> 5) & 1u;

            uint bit24 = (n >> 24) & 1u;
            uint bit25 = (n >> 25) & 1u;
            uint bit26 = (n >> 26) & 1u;

            n = ChangeBit(n, (byte)bit3, 24);
            n = ChangeBit(n, (byte)bit24, 3);

            n = ChangeBit(n, (byte)bit4, 25);
            n = ChangeBit(n, (byte)bit25, 4);

            n = ChangeBit(n, (byte)bit5, 26);
            n = ChangeBit(n, (byte)bit26, 5);

            Console.WriteLine(n);

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