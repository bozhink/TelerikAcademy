namespace SchoolSystem.Core
{
    using System;
    using Contracts;

    internal class ConsoleReader : IConsoleReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
