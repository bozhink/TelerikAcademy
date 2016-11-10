namespace Dealership.Core
{
    using System;
    using Dealership.Contracts;

    internal class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
