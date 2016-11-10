namespace Dealership.Services.Contracts
{
    using Dealership.Contracts.Models;

    public interface ISignInManagerService
    {
        IUser LoggedUser { get; }

        object Login(string username, string password);

        object Logout();
    }
}
