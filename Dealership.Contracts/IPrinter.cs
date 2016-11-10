namespace Dealership.Contracts
{
    using System.Threading.Tasks;

    public interface IPrinter
    {
        Task<bool> Print(string text);
    }
}
