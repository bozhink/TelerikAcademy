namespace Dealership.Handlers
{
    using System;
    using System.Text;
    using Constants;
    using Contracts.Engine;
    using Contracts.Handlers;
    using Dealership.Common;
    using Dealership.Common.Enums;
    using Dealership.Data.Contracts.Repositories;
    using Dealership.Services.Contracts;

    internal class ShowUsersCommandHandler : ICommandHandler
    {
        private readonly IUsersRepository usersRepository;

        public ShowUsersCommandHandler(IUsersRepository usersRepository)
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

            return command.Name == CommandNames.ShowUsersCommandName;
        }

        public object Execute(ICommand command, ISignInManagerService signInManager)
        {
            if (signInManager == null)
            {
                throw new ArgumentNullException(nameof(signInManager));
            }

            return this.ShowAllUsers(signInManager);
        }

        private string ShowAllUsers(ISignInManagerService signInManager)
        {
            if (signInManager.LoggedUser.Role != Role.Admin)
            {
                return Messages.YouAreNotAnAdmin;
            }

            var builder = new StringBuilder();
            builder.AppendLine("--USERS--");
            var counter = 1;
            foreach (var user in this.usersRepository.All())
            {
                builder.AppendLine(string.Format("{0}. {1}", counter, user.ToString()));
                counter++;
            }

            return builder.ToString().Trim();
        }
    }
}
