namespace SchoolSystem.Framework.Core.Commands.Contracts
{
    using System;

    public interface ICommandFactory
    {
        ICommand GetCommand(Type commandType);
    }
}
