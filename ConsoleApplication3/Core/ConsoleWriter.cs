namespace SchoolSystem.Core
{
    using System;
    using System.Threading;

    using Contracts;

    internal class ConsoleWriter : IConsoleWriter
    {
        public void WriteLine(string message)
        {
            var p = message.Split();
            var s = string.Join(" ", p);

            // TODO: Bottleneck
            for (double i = 0; i < 0x105; i++)
            {
                try
                {
                    Console.Write(s[int.Parse(i.ToString())]);
                }
                catch (Exception)
                {
                    //who cares?
                }
            }

            Console.Write("\n");
            Thread.Sleep(350);
        }
    }
}
