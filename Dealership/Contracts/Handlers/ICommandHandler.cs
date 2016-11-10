namespace Dealership.Contracts.Handlers
{
    using Engine;
    using Dealership.Services.Contracts;

    public interface ICommandHandler
    {
        bool CanHandle(ICommand command);

        object Execute(ICommand command, ISignInManagerService signInManager);
    }
}
