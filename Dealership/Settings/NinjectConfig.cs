namespace Dealership.Settings
{
    using System.Reflection;
    using Ninject;

    internal static class NinjectConfig
    {
        internal static IKernel CreateKernel()
        {
            var kernelSettings = new NinjectSettings
            {
                InjectNonPublic = true
            };

            var kernel = new StandardKernel(kernelSettings);

            try
            {
                kernel.Load(Assembly.GetExecutingAssembly());
            }
            catch
            {
                kernel.Dispose();
                throw;
            }

            return kernel;
        }
    }
}
