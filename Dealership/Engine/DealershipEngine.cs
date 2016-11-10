namespace Dealership.Engine
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Contracts.Handlers;
    using Dealership.Common;
    using Dealership.Common.Enums;
    using Dealership.Contracts.Engine;
    using Dealership.Contracts.Factories;
    using Dealership.Contracts.Models;
    using Dealership.Data.Contracts.Repositories;
    using System.Linq;
    using Constants;

    public sealed class DealershipEngine : IEngine
    {
        private readonly IDealershipFactory factory;
        private readonly IUsersRepository usersRepository;
        private readonly IEnumerable<ICommandHandler> commandHanlers;
        private IUser loggedUser;

        public DealershipEngine(IDealershipFactory factory, IUsersRepository usersRepository, IEnumerable<ICommandHandler> commandHanlers)
        {
            if (factory == null)
            {
                throw new ArgumentNullException(nameof(factory));
            }

            if (usersRepository == null)
            {
                throw new ArgumentNullException(nameof(usersRepository));
            }

            if (commandHanlers == null)
            {
                throw new ArgumentNullException(nameof(commandHanlers));
            }

            this.factory = factory;
            this.usersRepository = usersRepository;
            this.commandHanlers = commandHanlers;
            this.loggedUser = null;
        }

        public void Reset()
        {
            this.usersRepository.Reset();
            this.loggedUser = null;
            var commands = new List<ICommand>();
            var commandResult = new List<string>();
            this.PrintReports(commandResult);
        }

        public void Start()
        {
            Console.WriteLine(commandHanlers.Count());

            foreach (var h in commandHanlers)
            {
                Console.WriteLine(h);
            }


            var commands = this.ReadCommands();
            var commandResult = this.ProcessCommands(commands);
            this.PrintReports(commandResult);
        }

        private string AddComment(string content, int vehicleIndex, string author)
        {
            var comment = this.factory.CreateComment(content);
            comment.Author = this.loggedUser.Username;
            var user = this.usersRepository.GetByUserName(author);

            if (user == null)
            {
                return string.Format(Messages.NoSuchUser, author);
            }

            Validator.ValidateIntRange(vehicleIndex, 0, user.Vehicles.Count, Messages.VehicleDoesNotExist);

            var vehicle = user.Vehicles[vehicleIndex];

            this.loggedUser.AddComment(comment, vehicle);

            return string.Format(Messages.CommentAddedSuccessfully, this.loggedUser.Username);
        }

        private string AddVehicle(VehicleType type, string make, string model, decimal price, string additionalParam)
        {
            IVehicle vehicle = null;

            if (type == VehicleType.Car)
            {
                vehicle = this.factory.CreateCar(make, model, price, int.Parse(additionalParam));
            }
            else if (type == VehicleType.Motorcycle)
            {
                vehicle = this.factory.CreateMotorcycle(make, model, price, additionalParam);
            }
            else if (type == VehicleType.Truck)
            {
                vehicle = this.factory.CreateTruck(make, model, price, int.Parse(additionalParam));
            }

            this.loggedUser.AddVehicle(vehicle);

            return string.Format(Messages.VehicleAddedSuccessfully, this.loggedUser.Username);
        }

        private string Login(string username, string password)
        {
            if (this.loggedUser != null)
            {
                return string.Format(Messages.UserLoggedInAlready, this.loggedUser.Username);
            }

            var userFound = this.usersRepository.GetByUserName(username, true);
            if (userFound != null && userFound.Password == password)
            {
                this.loggedUser = userFound;
                return string.Format(Messages.UserLoggedIn, username);
            }

            return Messages.WrongUsernameOrPassword;
        }

        private string Logout()
        {
            this.loggedUser = null;
            return Messages.UserLoggedOut;
        }

        private void PrintReports(IList<string> reports)
        {
            var output = new StringBuilder();

            foreach (var report in reports)
            {
                output.AppendLine(report);
                output.AppendLine(new string('#', 20));
            }

            Console.Write(output.ToString());
        }

        private IList<string> ProcessCommands(IList<ICommand> commands)
        {
            var reports = new List<string>();

            foreach (var command in commands)
            {
                try
                {
                    var report = this.ProcessSingleCommand(command);
                    reports.Add(report);
                }
                catch (Exception ex)
                {
                    reports.Add(ex.Message);
                }
            }

            return reports;
        }

        private string ProcessSingleCommand(ICommand command)
        {
            if (command.Name != CommandNames.RegisterUserCommandName && command.Name != CommandNames.LoginCommandName)
            {
                if (this.loggedUser == null)
                {
                    return Messages.UserNotLogged;
                }
            }

            switch (command.Name)
            {
                case CommandNames.RegisterUserCommandName:
                    return RegisterUserCommandHandler(command);

                case CommandNames.LoginCommandName:
                    return LoginCommandHandler(command);

                case CommandNames.LogoutCommandName:
                    return LogoutCommandHandler();

                case CommandNames.AddVehicleCommandName:
                    return AddVehicleCommandHandler(command);

                case CommandNames.RemoveVehicleCommandName:
                    return RemoveVehicleCommandHandler(command);

                case CommandNames.AddCommentCommandName:
                    return AddCommentCommandHandler(command);

                case CommandNames.RemoveCommentCommandName:
                    return RemoveCommentCommandHanler(command);

                case CommandNames.ShowUsersCommandName:

                    return ShowUsersCommandHandler();

                case CommandNames.ShowVehiclesCommandName:
                    return ShowVehiclesCommandHandler(command);

                default:
                    return string.Format(Messages.InvalidCommand, command.Name);
            }
        }

        private string ShowVehiclesCommandHandler(ICommand command)
        {
            var username = command.Parameters[0];

            return this.ShowUserVehicles(username);
        }

        private string ShowUsersCommandHandler()
        {
            return this.ShowAllUsers();
        }

        private string RemoveCommentCommandHanler(ICommand command)
        {
            var vehicleIndex = int.Parse(command.Parameters[0]) - 1;
            var commentIndex = int.Parse(command.Parameters[1]) - 1;
            var username = command.Parameters[2];

            return this.RemoveComment(vehicleIndex, commentIndex, username);
        }

        private string AddCommentCommandHandler(ICommand command)
        {
            var content = command.Parameters[0];
            var author = command.Parameters[1];
            var vehicleIndex = int.Parse(command.Parameters[2]) - 1;

            return this.AddComment(content, vehicleIndex, author);
        }

        private string RemoveVehicleCommandHandler(ICommand command)
        {
            var vehicleIndex = int.Parse(command.Parameters[0]) - 1;
            return this.RemoveVehicle(vehicleIndex);
        }

        private string AddVehicleCommandHandler(ICommand command)
        {
            var type = command.Parameters[0];
            var make = command.Parameters[1];
            var model = command.Parameters[2];
            var price = decimal.Parse(command.Parameters[3]);
            var additionalParam = command.Parameters[4];

            var typeEnum = (VehicleType)Enum.Parse(typeof(VehicleType), type, true);

            return this.AddVehicle(typeEnum, make, model, price, additionalParam);
        }

        private string LogoutCommandHandler()
        {
            return this.Logout();
        }

        private string LoginCommandHandler(ICommand command)
        {
            var username = command.Parameters[0];
            var password = command.Parameters[1];

            return this.Login(username, password);
        }

        private string RegisterUserCommandHandler(ICommand command)
        {
            var username = command.Parameters[0];
            var firstName = command.Parameters[1];
            var lastName = command.Parameters[2];
            var password = command.Parameters[3];
            var role = Role.Normal;

            if (command.Parameters.Count > 4)
            {
                role = (Role)Enum.Parse(typeof(Role), command.Parameters[4]);
            }

            return this.RegisterUser(username, firstName, lastName, password, role);
        }

        private IList<ICommand> ReadCommands()
        {
            var commands = new List<ICommand>();

            var currentLine = Console.ReadLine();

            while (!string.IsNullOrEmpty(currentLine))
            {
                var currentCommand = new Command(currentLine);
                commands.Add(currentCommand);

                currentLine = Console.ReadLine();
            }

            return commands;
        }

        private string RegisterUser(string username, string firstName, string lastName, string password, Role role)
        {
            if (this.loggedUser != null)
            {
                return string.Format(Messages.UserLoggedInAlready, this.loggedUser.Username);
            }

            if (this.usersRepository.GetByUserName(username, true) != null)
            {
                return string.Format(Messages.UserAlreadyExist, username);
            }

            var user = this.factory.CreateUser(username, firstName, lastName, password, role.ToString());
            this.loggedUser = user;
            this.usersRepository.Add(user);

            return string.Format(Messages.UserRegisterеd, username);
        }

        private string RemoveComment(int vehicleIndex, int commentIndex, string username)
        {
            var user = this.usersRepository.GetByUserName(username);

            if (user == null)
            {
                return string.Format(Messages.NoSuchUser, username);
            }

            Validator.ValidateIntRange(vehicleIndex, 0, user.Vehicles.Count, Messages.RemovedVehicleDoesNotExist);
            Validator.ValidateIntRange(commentIndex, 0, user.Vehicles[vehicleIndex].Comments.Count, Messages.RemovedCommentDoesNotExist);

            var vehicle = user.Vehicles[vehicleIndex];
            var comment = user.Vehicles[vehicleIndex].Comments[commentIndex];

            this.loggedUser.RemoveComment(comment, vehicle);

            return string.Format(Messages.CommentRemovedSuccessfully, this.loggedUser.Username);
        }

        private string RemoveVehicle(int vehicleIndex)
        {
            Validator.ValidateIntRange(vehicleIndex, 0, this.loggedUser.Vehicles.Count, Messages.RemovedVehicleDoesNotExist);

            var vehicle = this.loggedUser.Vehicles[vehicleIndex];

            this.loggedUser.RemoveVehicle(vehicle);

            return string.Format(Messages.VehicleRemovedSuccessfully, this.loggedUser.Username);
        }

        private string ShowAllUsers()
        {
            if (this.loggedUser.Role != Role.Admin)
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
