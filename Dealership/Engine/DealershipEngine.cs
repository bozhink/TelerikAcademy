namespace Dealership.Engine
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Constants;
    using Contracts.Handlers;
    using Dealership.Common;
    using Dealership.Contracts.Engine;
    using Dealership.Services.Contracts;

    public sealed class DealershipEngine : IEngine
    {
        private readonly IEnumerable<ICommandHandler> commandHanlers;
        private readonly ISignInManagerService signInManager;

        public DealershipEngine(ISignInManagerService signInManager, IEnumerable<ICommandHandler> commandHanlers)
        {
            if (signInManager == null)
            {
                throw new ArgumentNullException(nameof(signInManager));
            }

            if (commandHanlers == null)
            {
                throw new ArgumentNullException(nameof(commandHanlers));
            }

            this.signInManager = signInManager;
            this.commandHanlers = commandHanlers;
        }

        public void Start()
        {
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

            foreach (var handler in this.commandHanlers)
            {
                if (handler.CanHandle(command))
                {
                    return handler.Execute(command, this.signInManager).ToString();
                }
            }

            return string.Format(Messages.InvalidCommand, command.Name);
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
