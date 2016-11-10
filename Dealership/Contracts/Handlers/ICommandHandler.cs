namespace Dealership.Contracts.Handlers
{
    using Engine;

    public interface ICommandHandler
    {
        bool CanHandle(ICommand command);

        object Execute(ICommand command);
    }
}
