namespace SchoolSystem.Cli
{
    using Ninject;
    using SchoolSystem.Framework.Core.Contracts;

    public class Startup
    {
        public static void Main()
        {
            using (var kernel = new StandardKernel(new SchoolSystemModule()))
            {
                var engine = kernel.Get<IEngine>();
                engine.Start();
            }
        }
    }
}
