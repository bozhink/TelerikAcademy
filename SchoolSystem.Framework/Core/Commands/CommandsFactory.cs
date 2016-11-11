using SchoolSystem.Framework.Core.Commands.Contracts;
using System;

namespace SchoolSystem.Framework.Core.Commands
{
    public class CommandsFactory : ICommandFactory
    {
        private readonly Func<Type, ICommand> commandFactory;

        public CommandsFactory(Func<Type, ICommand> commandFactory)
        {
            if (commandFactory == null)
            {
                throw new ArgumentNullException(nameof(commandFactory));
            }

            this.commandFactory = commandFactory;
        }

        public ICommand GetCommand(Type commandType)
        {
            if (commandType == null)
            {
                throw new ArgumentNullException(nameof(commandType));
            }

            return this.commandFactory(commandType);
        }
    }
}
