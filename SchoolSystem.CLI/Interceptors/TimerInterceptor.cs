namespace SchoolSystem.Cli.Interceptors
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using Ninject.Extensions.Interception;
    using SchoolSystem.Cli.Configuration;
    using SchoolSystem.Framework.Core.Contracts;

    public class TimerInterceptor : IInterceptor
    {
        private readonly IConfigurationProvider configurationProvider;
        private readonly IWriter writer;

        public TimerInterceptor(IConfigurationProvider configurationProvider, IWriter writer)
        {
            if (configurationProvider == null)
            {
                throw new ArgumentNullException(nameof(configurationProvider));
            }

            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }

            this.configurationProvider = configurationProvider;
            this.writer = writer;
        }

        public void Intercept(IInvocation invocation)
        {
            if (this.configurationProvider.IsTestEnvironment)
            {
                string methodName = invocation.Request.Method.Name;
                string typeName = invocation.Request.Target.GetType()
                    .GetInterfaces().FirstOrDefault() //// This is an ugly hack
                    .Name;

                this.writer.WriteLine($"Calling method {methodName} of type {typeName}...");

                var timer = new Stopwatch();
                timer.Start();

                invocation.Proceed();

                this.writer.WriteLine($"Total execution time for method {methodName} of type {typeName} is {timer.ElapsedMilliseconds.ToString()} milliseconds.");
            }
            else
            {
                invocation.Proceed();
            }
        }
    }
}
