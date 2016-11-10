namespace Dealership.Settings
{
    using System.IO;
    using System.Reflection;
    using Contracts.Engine;
    using Engine;
    using Ninject.Extensions.Conventions;
    using Ninject.Modules;
    using Ninject;
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

            this.Bind<IEnumerable<ICommandHandler>>()
                .ToMethod(context => Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .Where(t => t.IsClass && !t.IsAbstract && typeof(ICommandHandler).IsAssignableFrom(t))
                    .Select(t => (ICommandHandler)context.Kernel.Get(t)));
        }
    }
}
