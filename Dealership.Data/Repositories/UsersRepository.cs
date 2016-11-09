namespace Dealership.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Contracts.Repositories;
    using Dealership.Contracts.Models;

    public class UsersRepository : IUsersRepository
    {
        private readonly IUsersDbContext db;

        public UsersRepository(IUsersDbContext db)
        {
            if (db == null)
            {
                throw new ArgumentNullException(nameof(db));
            }

            this.db = db;
        }

        public IEnumerable<IUser> All() => this.db.Users;

        public bool Add(IUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            this.db.Users.Add(user);

            return true;
        }

        public IUser GetByUserName(string userName, bool caseSensitive = false)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException(nameof(userName));
            }

            if (caseSensitive)
            {
                return this.db.Users.FirstOrDefault(u => u.Username.ToLower() == userName.ToLower());
            }
            else
            {
                return this.db.Users.FirstOrDefault(u => u.Username == userName);
            }
        }

        public bool Reset() => this.db.Reset();
    }
}
