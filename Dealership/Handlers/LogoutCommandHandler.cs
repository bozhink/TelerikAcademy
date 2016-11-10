namespace Dealership.Handlers
{
    using System;
    using Constants;
    using Contracts.Engine;
    using Contracts.Handlers;
    using Dealership.Services.Contracts;

    internal class LogoutCommandHandler : ICommandHandler
    {
        public bool CanHandle(ICommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            return command.Name == CommandNames.LogoutCommandName;
        }

        public object Execute(ICommand command, ISignInManagerService signInManager)
        {
            if (signInManager == null)
            {
                throw new ArgumentNullException(nameof(signInManager));
            }

            return signInManager.Logout();
        }
    }
}
