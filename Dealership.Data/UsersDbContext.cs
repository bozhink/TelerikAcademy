namespace Dealership.Data
{
    using System.Collections.Generic;
    using Contracts;
    using Dealership.Contracts.Models;

    public class UsersDbContext : IUsersDbContext
    {
        public UsersDbContext()
        {
            this.Initialize();
        }

        public ICollection<IUser> Users { get; private set; }

        public bool Reset() => this.Initialize();

        private bool Initialize()
        {
            this.Users = new List<IUser>();
            return true;
        }
    }
}
