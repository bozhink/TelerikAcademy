namespace Dealership
{
    using Contracts.Engine;
    using Ninject;
    using Settings;

    public class Startup
    {
        public static void Main()
        {
            using (var kernel = NinjectConfig.CreateKernel())
            {
                var engine = kernel.Get<IEngine>();
                engine.Start();
            }
        }
    }
}
