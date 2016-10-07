namespace SchoolSystem.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Contracts;

    internal class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
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
                    if (stringCommand == "End")
                    {
                        break;
                    }

                    var commandName = stringCommand.Split(' ')[0];

                    var assembly = this.GetType().GetTypeInfo().Assembly;
                    var typeInfo = assembly.DefinedTypes
                        .Where(type => type.ImplementedInterfaces.Any(inter => inter == typeof(ICommand)))
                        .Where(type => type.Name.ToLower().Contains(commandName.ToLower()))
                        .FirstOrDefault();

                    if (typeInfo == null)
                    {
                        throw new ArgumentException("The passed command is not found!");
                    }

                    var parameters = stringCommand.Split(' ').ToList();
                    parameters.RemoveAt(0);

                    var commandInstance = Activator.CreateInstance(typeInfo) as ICommand;
                    this.writer.WriteLine(commandInstance.Execute(parameters));
                }
                catch (Exception ex)
                {
                    this.writer.WriteLine(ex.Message);
                }
            }
        }
    }
}
