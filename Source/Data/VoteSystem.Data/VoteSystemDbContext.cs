namespace VoteSystem.Data
{
    using System.Data.Entity;

    using Microsoft.AspNet.Identity.EntityFramework;

    using VoteSystem.Data.Migrations;
    using VoteSystem.Data.Models;

    public class VoteSystemDbContext : IdentityDbContext<User>, IVoteSystemDbContext
    {
        public VoteSystemDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public virtual IDbSet<Question> Questions { get; set; }

        public virtual IDbSet<VoteSystem> VoteSystems { get; set; }

        public static VoteSystemDbContext Create()
        {
            return new VoteSystemDbContext();
        }
    }
}
