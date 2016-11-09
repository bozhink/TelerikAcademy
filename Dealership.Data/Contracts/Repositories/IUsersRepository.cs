namespace Dealership.Data.Contracts.Repositories
{
    using System.Collections.Generic;
    using Dealership.Contracts.Models;

    public interface IUsersRepository
    {
        IEnumerable<IUser> All();

        bool Add(IUser user);

        IUser GetByUserName(string userName, bool caseSensitive = false);

        bool Reset();
    }
}
