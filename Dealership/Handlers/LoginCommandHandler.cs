namespace Dealership.Handlers
{
    using System;
    using Constants;
    using Contracts.Engine;
    using Contracts.Handlers;
    using Dealership.Services.Contracts;

    internal class LoginCommandHandler : ICommandHandler
    {
        public bool CanHandle(ICommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            return command.Name == CommandNames.LoginCommandName;
        }

        public object Execute(ICommand command, ISignInManagerService signInManager)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            if (signInManager == null)
            {
                throw new ArgumentNullException(nameof(signInManager));
            }

            var username = command.Parameters[0];
            var password = command.Parameters[1];

            return signInManager.Login(username, password);
        }
    }
}
