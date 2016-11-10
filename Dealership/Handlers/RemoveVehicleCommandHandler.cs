namespace Dealership.Handlers
{
    using System;
    using Constants;
    using Contracts.Engine;
    using Contracts.Handlers;
    using Dealership.Common;
    using Dealership.Contracts.Models;
    using Dealership.Services.Contracts;

    internal class RemoveVehicleCommandHandler : ICommandHandler
    {
        public bool CanHandle(ICommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            return command.Name == CommandNames.RemoveVehicleCommandName;
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
            return this.RemoveVehicle(signInManager.LoggedUser, vehicleIndex);
        }

        private string RemoveVehicle(IUser loggedUser, int vehicleIndex)
        {
            if (loggedUser == null)
            {
                return Messages.UserNotLogged;
            }

            Validator.ValidateIntRange(vehicleIndex, 0, loggedUser.Vehicles.Count, Messages.RemovedVehicleDoesNotExist);

            var vehicle = loggedUser.Vehicles[vehicleIndex];

            loggedUser.RemoveVehicle(vehicle);

            return string.Format(Messages.VehicleRemovedSuccessfully, loggedUser.Username);
        }
    }
}
