namespace Dealership.Services
{
    using System;
    using Common;
    using Contracts;
    using Dealership.Contracts.Models;
    using Dealership.Data.Contracts.Repositories;

    public class SignInManagerService : ISignInManagerService
    {
        private readonly IUsersRepository usersRepository;

        public SignInManagerService(IUsersRepository usersRepository)
        {
            if (usersRepository == null)
            {
                throw new ArgumentNullException(nameof(usersRepository));
            }

            this.usersRepository = usersRepository;
        }

        public IUser LoggedUser { get; private set; } = null;

        public object Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentNullException(nameof(username));
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentNullException(nameof(password));
            }

            if (this.LoggedUser != null)
            {
                return string.Format(Messages.UserLoggedInAlready, this.LoggedUser.Username);
            }

            var userFound = this.usersRepository.GetByUserName(username, true);
            if (userFound != null && userFound.Password == password)
            {
                this.LoggedUser = userFound;
                return string.Format(Messages.UserLoggedIn, username);
            }

            return Messages.WrongUsernameOrPassword;
        }

        public object Logout()
        {
            this.LoggedUser = null;
            return Messages.UserLoggedOut;
        }
    }
}
