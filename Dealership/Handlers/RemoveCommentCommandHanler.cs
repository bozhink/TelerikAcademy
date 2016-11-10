namespace Dealership.Handlers
{
    using System;
    using Constants;
    using Contracts.Engine;
    using Contracts.Handlers;
    using Dealership.Common;
    using Dealership.Contracts.Models;
    using Dealership.Data.Contracts.Repositories;
    using Dealership.Services.Contracts;

    internal class RemoveCommentCommandHanler : ICommandHandler
    {
        private readonly IUsersRepository usersRepository;

        public RemoveCommentCommandHanler(IUsersRepository usersRepository)
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

            return command.Name == CommandNames.RemoveCommentCommandName;
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

            var vehicleIndex = int.Parse(command.Parameters[0]) - 1;
            var commentIndex = int.Parse(command.Parameters[1]) - 1;
            var username = command.Parameters[2];

            return this.RemoveComment(signInManager.LoggedUser, vehicleIndex, commentIndex, username);
        }

        private string RemoveComment(IUser loggedUser, int vehicleIndex, int commentIndex, string username)
        {
            if (loggedUser == null)
            {
                return Messages.UserNotLogged;
            }

            var user = this.usersRepository.GetByUserName(username);
            if (user == null)
            {
                return string.Format(Messages.NoSuchUser, username);
            }

            Validator.ValidateIntRange(vehicleIndex, 0, user.Vehicles.Count, Messages.RemovedVehicleDoesNotExist);
            Validator.ValidateIntRange(commentIndex, 0, user.Vehicles[vehicleIndex].Comments.Count, Messages.RemovedCommentDoesNotExist);

            var vehicle = user.Vehicles[vehicleIndex];
            var comment = user.Vehicles[vehicleIndex].Comments[commentIndex];

            loggedUser.RemoveComment(comment, vehicle);

            return string.Format(Messages.CommentRemovedSuccessfully, loggedUser.Username);
        }
    }
}
