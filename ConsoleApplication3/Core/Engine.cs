namespace SchoolSystem.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Constants;
    using Contracts;

    internal class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private readonly IEnumerable<TypeInfo> commandTypes;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;

            var assembly = this.GetType().GetTypeInfo().Assembly;
            this.commandTypes = assembly.DefinedTypes
                .Where(type => type.ImplementedInterfaces.Any(inter => inter == typeof(ICommand)))
                .ToList();
        }

        public static IDictionary<int, ITeacher> Teachers { get; private set; } = new Dictionary<int, ITeacher>();

        public static IDictionary<int, IStudent> Students { get; private set; } = new Dictionary<int, IStudent>();

        public void Run()
        {
            while (true)
            {
                try
                {
                    var stringCommand = this.reader.ReadLine();
                    if (string.IsNullOrWhiteSpace(stringCommand))
                    {
                        continue;
                    }

                    if (stringCommand == CommandConstants.EndCommandValue)
                    {
                        break;
                    }

                    var commandInstance = this.GetCommandInstance(stringCommand);

                    var parameters = stringCommand.Split(' ').ToList();
                    parameters.RemoveAt(0);

                    this.writer.WriteLine(commandInstance.Execute(parameters));
                }
                catch (Exception ex)
                {
                    this.writer.WriteLine(ex.Message);
                }
            }
        }

        private ICommand GetCommandInstance(string stringCommand)
        {
            var commandName = stringCommand.Split(' ')[0];

            var commandType = this.commandTypes
                .Where(type => type.Name.ToLower().Contains(commandName.ToLower()))
                .FirstOrDefault();

            if (commandType == null)
            {
                throw new ArgumentException(Messages.CommandNotFoundErrorMessage);
            }

            var commandInstance = Activator.CreateInstance(commandType) as ICommand;
            return commandInstance;
        }
    }
}
