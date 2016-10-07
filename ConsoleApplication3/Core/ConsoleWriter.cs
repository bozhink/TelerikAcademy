namespace SchoolSystem.Core
{
    using System;
    using Contracts;

    internal class ConsoleWriter : IConsoleWriter
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
