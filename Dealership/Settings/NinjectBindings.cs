namespace Dealership.Settings
{
    using System;
    using System.IO;
    using System.Reflection;
    using Contracts.Engine;
    using Engine;
    using Dealership.Contracts;
    using Ninject.Extensions.Conventions;
    using Ninject.Modules;
    using Ninject;
    using Core;
    using System.Collections.Generic;
    using Contracts.Handlers;
    using System.Linq;

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

            this.Bind<IReporter>()
                .To<Reporter>()
                .InSingletonScope();

            this.Bind<Func<Type, ICommandHandler>>()
                .ToMethod(context => t => (ICommandHandler)context.Kernel.Get(t))
                .InSingletonScope();
        }
    }
}
