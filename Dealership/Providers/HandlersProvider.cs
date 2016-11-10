namespace Dealership.Providers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Contracts.Handlers;
    using Contracts.Providers;

    /// <summary>
    /// Ninject cannot bind directly IEnumerable<ICommandHandler>, so we need here this provider.
    /// </summary>
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
            string defaultCommandHadlerInterfaceFullName = typeof(ICommandHandler).FullName;

            var query = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.IsClass && !t.IsGenericType && !t.IsAbstract)
                .Where(t => t.GetInterfaces().Any(i => i.FullName == defaultCommandHadlerInterfaceFullName))
                .Select(t => this.commandHandlerFactory(t));

            return query.ToArray();
        }
    }
}
