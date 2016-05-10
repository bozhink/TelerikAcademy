namespace Users.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;

    public class UsersDbContext : IdentityDbContext<ApplicationUser>
    {
        public UsersDbContext()
            : base("UsersDbConnection", throwIfV1Schema: false)
        {
        }
        
        public static UsersDbContext Create()
        {
            return new UsersDbContext();
        }
    }
}