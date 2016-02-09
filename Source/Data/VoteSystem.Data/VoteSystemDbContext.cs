namespace VoteSystem.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;

    using VoteSystem.Models;

    public class VoteSystemDbContext : IdentityDbContext<User>
    {
        public VoteSystemDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static VoteSystemDbContext Create()
        {
            return new VoteSystemDbContext();
        }
    }
}
