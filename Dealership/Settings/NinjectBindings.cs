namespace Dealership.Settings
{
    using System;
    using System.IO;
    using System.Reflection;
    using Dealership.Contracts;
    using Dealership.Contracts.Core;
    using Dealership.Contracts.Engine;
    using Dealership.Contracts.Handlers;
    using Dealership.Core;
    using Dealership.Engine;
    using Ninject;
    using Ninject.Extensions.Conventions;
    using Ninject.Modules;

    public class NinjectBindings : NinjectModule
    {
        public override void Load()
        {
            this.Bind(b =>
            {
                b.FromAssembliesInPath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                 .SelectAllClasses()
                 .BindDefaultInterface();
            });

            this.Bind<IEngine>()
                .To<DealershipEngine>();

            this.Bind<IPrinter>()
                .To<ConsolePrinter>()
                .InSingletonScope();

            this.Bind<IReader>()
                .To<ConsoleReader>()
                .InSingletonScope();

            this.Bind<IReporter>()
                .To<Reporter>()
                .InSingletonScope();

            this.Bind<ICommandReader>()
                .To<CommandReader>()
                .InSingletonScope();

            this.Bind<Func<Type, ICommandHandler>>()
                .ToMethod(context => t => (ICommandHandler)context.Kernel.Get(t))
                .InSingletonScope();
        }
    }
}
