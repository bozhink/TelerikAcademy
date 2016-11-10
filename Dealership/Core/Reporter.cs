namespace Dealership.Core
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using Dealership.Contracts;

    internal class Reporter : IReporter
    {
        private readonly IPrinter printer;

        public Reporter(IPrinter printer)
        {
            if (printer == null)
            {
                throw new ArgumentNullException(nameof(printer));
            }

            this.printer = printer;
        }

        public Task<bool> PrintReports(IEnumerable<string> reports)
        {
            if (reports == null)
            {
                throw new ArgumentNullException(nameof(reports));
            }

            var output = new StringBuilder();

            foreach (var report in reports)
            {
                output.AppendLine(report);
                output.AppendLine(new string('#', 20));
            }

            return this.printer.Print(output.ToString());
        }
    }
}
