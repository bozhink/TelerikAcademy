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
    using Dealership.Services.Contracts;

    public sealed class DealershipEngine : IEngine
    {
        private readonly IDealershipFactory factory;
        private readonly IUsersRepository usersRepository;
        private readonly IEnumerable<ICommandHandler> commandHanlers;
        private readonly ISignInManagerService signInManager;

        public DealershipEngine(IDealershipFactory factory, IUsersRepository usersRepository, ISignInManagerService signInManager, IEnumerable<ICommandHandler> commandHanlers)
        {
            if (factory == null)
            {
                throw new ArgumentNullException(nameof(factory));
            }

            if (usersRepository == null)
            {
                throw new ArgumentNullException(nameof(usersRepository));
            }

            if (signInManager == null)
            {
                throw new ArgumentNullException(nameof(signInManager));
            }

            if (commandHanlers == null)
            {
                throw new ArgumentNullException(nameof(commandHanlers));
            }

            this.factory = factory;
            this.usersRepository = usersRepository;
            this.signInManager = signInManager;
            this.commandHanlers = commandHanlers;
        }

        public void Reset()
        {
            this.usersRepository.Reset();
            this.signInManager.Logout();

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
                if (this.signInManager.LoggedUser == null)
                {
                    return Messages.UserNotLogged;
                }
            }

            switch (command.Name)
            {
                ////case CommandNames.RegisterUserCommandName:
                ////    return RegisterUserCommandHandler(command);

                ////case CommandNames.LoginCommandName:
                ////    return LoginCommandHandler(command);

                ////case CommandNames.LogoutCommandName:
                ////    return LogoutCommandHandler();

                ////case CommandNames.AddVehicleCommandName:
                ////    return AddVehicleCommandHandler(command);

                ////case CommandNames.RemoveVehicleCommandName:
                ////    return RemoveVehicleCommandHandler(command);

                ////case CommandNames.AddCommentCommandName:
                ////    return AddCommentCommandHandler(command);

                ////case CommandNames.RemoveCommentCommandName:
                ////    return RemoveCommentCommandHanler(command);

                ////case CommandNames.ShowUsersCommandName:
                ////    return ShowUsersCommandHandler();

                ////case CommandNames.ShowVehiclesCommandName:
                ////    return ShowVehiclesCommandHandler(command);

                default:
                    return string.Format(Messages.InvalidCommand, command.Name);
            }
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





    }
}
