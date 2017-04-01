using System;
using System.Data.Entity;
using System.Linq;

using Microsoft.AspNet.Identity.EntityFramework;
using VoteSystem.Data.Models;

using VoteSystem.Data.Contracts;
using VoteSystem.Data.Models.Common;

namespace VoteSystem.Data
{
    public class VoteSystemDbContext : DbContext, IVoteSystemDbContext
    {
        public VoteSystemDbContext()
            : base("DefaultConnection")
        {
        }

        public virtual IDbSet<Question> Questions { get; set; }

        public virtual IDbSet<Participant> Participants { get; set; }

        public virtual IDbSet<ParticipantAnswer> ParticipantAnswers { get; set; }

        public virtual IDbSet<Survey> RateSystems { get; set; }

        public virtual IDbSet<QuestionAnswer> QuestionAnswers { get; set; }

        public static VoteSystemDbContext Create()
        {
            return new VoteSystemDbContext();
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            // ChangeTracker get all changes before they go to the Database
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;

                if (entry.State == EntityState.Added && entity.CreatedOn == default(DateTime))
                {
                    entity.CreatedOn = DateTime.Now;
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }
    }
}
