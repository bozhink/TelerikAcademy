namespace Dealership.Settings
{
    using Contracts.Engine;
    using Engine;
    using Ninject.Extensions.Conventions;
    using Ninject.Modules;

    public class NinjectBindings : NinjectModule
    {
        public override void Load()
        {
            this.Bind(b =>
            {
                b.FromThisAssembly()
                 .SelectAllClasses()
                 .BindDefaultInterface();
            });

            this.Bind<IEngine>().To<DealershipEngine>();
        }
    }
}
