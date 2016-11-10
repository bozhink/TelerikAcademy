namespace Dealership.Core
{
    using System;
    using System.Threading.Tasks;
    using Dealership.Contracts;

    internal class ConsolePrinter : IPrinter
    {
        public async Task<bool> Print(string text)
        {
            await Console.Out.WriteAsync(text);
            return true;
        }
    }
}
