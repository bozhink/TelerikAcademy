namespace Dealership.Contracts.Providers
{
    using System.Collections.Generic;
    using Handlers;

    public interface IHandlersProvider
    {
        IEnumerable<ICommandHandler> GetCommandHandler();
    }
}
