namespace SchoolSystem.Framework.Core.Providers
{
    using System;
    using SchoolSystem.Framework.Core.Contracts;

    public class ConsoleReaderProvider : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
