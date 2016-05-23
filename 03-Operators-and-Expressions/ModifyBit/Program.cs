namespace ModifyBit
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            ulong n = ulong.Parse(Console.ReadLine());
            byte p = byte.Parse(Console.ReadLine());
            byte v = byte.Parse(Console.ReadLine());

            Console.WriteLine(ChangeBit(n, v, p));
        }

        public static ulong ChangeBit(ulong number, byte value, byte position)
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

        public static ulong Mask(byte position)
        {
            ulong mask = 1u;
            mask <<= position;
            return mask;
        }
    }
}