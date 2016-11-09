namespace Dealership.Data.Contracts
{
    using System.Collections.Generic;
    using Dealership.Contracts.Contracts.Data;
    using Dealership.Contracts.Models;

    public interface IUsersDbContext : IDbContext
    {
        ICollection<IUser> Users { get; }

        bool Reset();
    }
}
