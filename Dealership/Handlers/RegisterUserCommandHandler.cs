namespace Dealership.Handlers
{
    using System;
    using Constants;
    using Contracts.Engine;
    using Contracts.Factories;
    using Contracts.Handlers;
    using Dealership.Common;
    using Dealership.Common.Enums;
    using Dealership.Data.Contracts.Repositories;
    using Services.Contracts;

    internal class RegisterUserCommandHandler : ICommandHandler
    {
        private readonly IDealershipFactory factory;
        private readonly IUsersRepository usersRepository;

        public RegisterUserCommandHandler(IDealershipFactory factory, IUsersRepository usersRepository)
        {
            if (factory == null)
            {
                throw new ArgumentNullException(nameof(factory));
            }

            if (usersRepository == null)
            {
                throw new ArgumentNullException(nameof(usersRepository));
            }

            this.factory = factory;
            this.usersRepository = usersRepository;
        }

        public bool CanHandle(ICommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            return command.Name == CommandNames.RegisterUserCommandName;
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
            var firstName = command.Parameters[1];
            var lastName = command.Parameters[2];
            var password = command.Parameters[3];
            var role = Role.Normal;

            if (command.Parameters.Count > 4)
            {
                role = (Role)Enum.Parse(typeof(Role), command.Parameters[4]);
            }

            return this.RegisterUser(username, firstName, lastName, password, role, signInManager);
        }

        private string RegisterUser(string username, string firstName, string lastName, string password, Role role, ISignInManagerService signInManager)
        {
            if (signInManager.LoggedUser != null)
            {
                return string.Format(Messages.UserLoggedInAlready, signInManager.LoggedUser.Username);
            }

            if (this.usersRepository.GetByUserName(username, true) != null)
            {
                return string.Format(Messages.UserAlreadyExist, username);
            }

            var user = this.factory.CreateUser(username, firstName, lastName, password, role.ToString());
            this.usersRepository.Add(user);

            signInManager.Login(username, password);

            return string.Format(Messages.UserRegisterеd, username);
        }
    }
}
