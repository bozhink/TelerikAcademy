namespace Dealership.Handlers
{
    using System;
    using Constants;
    using Contracts.Engine;
    using Contracts.Handlers;
    using Dealership.Common;
    using Dealership.Data.Contracts.Repositories;
    using Dealership.Services.Contracts;

    internal class ShowVehiclesCommandHandler : ICommandHandler
    {
        private readonly IUsersRepository usersRepository;

        public ShowVehiclesCommandHandler(IUsersRepository usersRepository)
        {
            if (usersRepository == null)
            {
                throw new ArgumentNullException(nameof(usersRepository));
            }

            this.usersRepository = usersRepository;
        }

        public bool CanHandle(ICommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            return command.Name == CommandNames.ShowVehiclesCommandName;
        }

        public object Execute(ICommand command, ISignInManagerService signInManager)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            var username = command.Parameters[0];
            return this.ShowUserVehicles(username);
        }

        private string ShowUserVehicles(string username)
        {
            var user = this.usersRepository.GetByUserName(username, true);
            if (user == null)
            {
                return string.Format(Messages.NoSuchUser, username);
            }

            return user.PrintVehicles();
        }
    }
}
