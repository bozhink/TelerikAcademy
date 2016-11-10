////namespace Dealership.Handlers
////{
////    using System;
////    using Contracts.Handlers;
////    using Contracts.Engine;
////    using Constants;

////    internal class ShowVehiclesCommandHandler : ICommandHandler
////    {
////        public bool CanHandle(ICommand command)
////        {
////            if (command == null)
////            {
////                throw new ArgumentNullException(nameof(command));
////            }

////            return command.Name == CommandNames.ShowVehiclesCommandName;
////        }

////        public object Execute(ICommand command)
////        {
////            if (command == null)
////            {
////                throw new ArgumentNullException(nameof(command));
////            }

////            var username = command.Parameters[0];

////            return this.ShowUserVehicles(username);
////        }

////        private string ShowUserVehicles(string username)
////        {
////            var user = this.usersRepository.GetByUserName(username, true);

////            if (user == null)
////            {
////                return string.Format(NoSuchUser, username);
////            }

////            return user.PrintVehicles();
////        }
////    }
////}
