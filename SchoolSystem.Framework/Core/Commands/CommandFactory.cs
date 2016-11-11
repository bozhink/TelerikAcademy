using SchoolSystem.Framework.Core.Commands.Contracts;
using System;

namespace SchoolSystem.Framework.Core.Commands
{
    public class CommandFactory : ICommandFactory
    {
        private readonly Func<Type, ICommand> commandFactory;

        public CommandFactory(Func<Type, ICommand> commandFactory)
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
