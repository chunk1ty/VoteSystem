using System;
using System.Data.Entity;
using System.Linq;

using VoteSystem.Common.Constants;
using VoteSystem.Data.Contracts;
using VoteSystem.Data.Entities;
using VoteSystem.Data.Entities.Contracts;

namespace VoteSystem.Data
{
    public class VoteSystemDbContext : DbContext, IVoteSystemDbContext
    {
        public VoteSystemDbContext()
            : base(ConnectionStings.VoteSystemDbConnection)
        {
        }

        public virtual IDbSet<Question> Questions { get; set; }

        public virtual IDbSet<Participant> Participants { get; set; }

        public virtual IDbSet<ParticipantAnswer> ParticipantAnswers { get; set; }

        public virtual IDbSet<Survey> Surveys { get; set; }

        public virtual IDbSet<QuestionAnswer> QuestionAnswers { get; set; }

        public virtual IDbSet<VoteSystemUser> VoteSystemUsers { get; set; }

        public new IDbSet<TEntity> Set<TEntity>() 
            where TEntity : class
        {
            return base.Set<TEntity>();
        }

        //public static VoteSystemDbContext Create()
        //{
        //    return new VoteSystemDbContext();
        //}

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
