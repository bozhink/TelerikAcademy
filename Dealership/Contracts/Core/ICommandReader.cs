namespace Dealership.Contracts.Core
{
    using System.Collections.Generic;
    using Engine;

    public interface ICommandReader
    {
        IEnumerable<ICommand> ReadCommands();
    }
}
