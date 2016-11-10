namespace Dealership.Providers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Contracts.Handlers;
    using Contracts.Providers;

    public class HandlersProvider : IHandlersProvider
    {
        private readonly Func<Type, ICommandHandler> commandHandlerFactory;

        public HandlersProvider(Func<Type, ICommandHandler> commandHandlerFactory)
        {
            if (commandHandlerFactory == null)
            {
                throw new ArgumentNullException(nameof(commandHandlerFactory));
            }

            this.commandHandlerFactory = commandHandlerFactory;
        }

        public IEnumerable<ICommandHandler> GetCommandHandler()
        {
            return Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && typeof(ICommandHandler).IsAssignableFrom(t))
                .Select(t => (ICommandHandler)this.commandHandlerFactory(t));
        }
    }
}
