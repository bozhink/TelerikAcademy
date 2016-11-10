namespace Dealership.Core
{
    using System;
    using System.Collections.Generic;
    using Contracts.Core;
    using Contracts.Engine;
    using Dealership.Contracts;
    using Engine;

    internal class CommandReader : ICommandReader
    {
        private readonly IReader reader;

        public CommandReader(IReader reader)
        {
            if (reader == null)
            {
                throw new ArgumentNullException(nameof(reader));
            }

            this.reader = reader;
        }

        public IEnumerable<ICommand> ReadCommands()
        {
            var commands = new List<ICommand>();

            var currentLine = this.reader.ReadLine();
            while (!string.IsNullOrEmpty(currentLine))
            {
                var currentCommand = new Command(currentLine);
                commands.Add(currentCommand);

                currentLine = this.reader.ReadLine();
            }

            return commands;
        }
    }
}
