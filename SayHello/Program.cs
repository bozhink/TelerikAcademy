namespace SayHello
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            SayHello(Console.ReadLine());
        }

        public static void SayHello(string name)
        {
            Console.WriteLine("Hello, {0}!", name);
        }
    }
}