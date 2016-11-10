namespace Dealership.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IReporter
    {
        Task<bool> PrintReports(IEnumerable<string> reports);
    }
}
