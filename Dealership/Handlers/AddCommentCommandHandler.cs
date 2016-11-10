namespace Dealership.Handlers
{
    using System;
    using Constants;
    using Contracts.Engine;
    using Contracts.Factories;
    using Contracts.Handlers;
    using Dealership.Common;
    using Dealership.Contracts.Models;
    using Dealership.Data.Contracts.Repositories;
    using Dealership.Services.Contracts;

    internal class AddCommentCommandHandler : ICommandHandler
    {
        private readonly IDealershipFactory factory;
        private readonly IUsersRepository usersRepository;

        public AddCommentCommandHandler(IDealershipFactory factory, IUsersRepository usersRepository)
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

            return command.Name == CommandNames.AddCommentCommandName;
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

            var content = command.Parameters[0];
            var author = command.Parameters[1];
            var vehicleIndex = int.Parse(command.Parameters[2]) - 1;

            return this.AddComment(signInManager.LoggedUser, content, vehicleIndex, author);
        }

        private string AddComment(IUser loggedUser, string content, int vehicleIndex, string author)
        {
            if (loggedUser == null)
            {
                return Messages.UserNotLogged;
            }

            var comment = this.factory.CreateComment(content);
            comment.Author = loggedUser.Username;

            var user = this.usersRepository.GetByUserName(author);
            if (user == null)
            {
                return string.Format(Messages.NoSuchUser, author);
            }

            Validator.ValidateIntRange(vehicleIndex, 0, user.Vehicles.Count, Messages.VehicleDoesNotExist);

            var vehicle = user.Vehicles[vehicleIndex];

            loggedUser.AddComment(comment, vehicle);

            return string.Format(Messages.CommentAddedSuccessfully, loggedUser.Username);
        }
    }
}
