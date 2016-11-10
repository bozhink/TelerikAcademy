namespace Dealership.Engine
{
    using System;
    using System.Collections.Generic;
    using Dealership.Common;
    using Dealership.Constants;
    using Dealership.Contracts;
    using Dealership.Contracts.Core;
    using Dealership.Contracts.Engine;
    using Dealership.Contracts.Handlers;
    using Dealership.Contracts.Providers;
    using Dealership.Services.Contracts;

    public sealed class DealershipEngine : IEngine
    {
        private readonly IEnumerable<ICommandHandler> commandHanlers;
        private readonly ISignInManagerService signInManager;
        private readonly IReporter reporter;
        private readonly ICommandReader reader;

        public DealershipEngine(
            ISignInManagerService signInManager,
            IHandlersProvider handlersProvider,
            IReporter reporter,
            ICommandReader reader)
        {
            if (signInManager == null)
            {
                throw new ArgumentNullException(nameof(signInManager));
            }

            if (handlersProvider == null)
            {
                throw new ArgumentNullException(nameof(handlersProvider));
            }

            if (reporter == null)
            {
                throw new ArgumentNullException(nameof(reporter));
            }

            if (reader == null)
            {
                throw new ArgumentNullException(nameof(reader));
            }

            this.signInManager = signInManager;
            this.commandHanlers = handlersProvider.GetCommandHandler();
            this.reporter = reporter;
            this.reader = reader;
        }

        public void Start()
        {
            var commands = this.reader.ReadCommands();
            var commandResult = this.ProcessCommands(commands);

            this.reporter.PrintReports(commandResult).Wait();
        }

        private IEnumerable<string> ProcessCommands(IEnumerable<ICommand> commands)
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
    }
}
