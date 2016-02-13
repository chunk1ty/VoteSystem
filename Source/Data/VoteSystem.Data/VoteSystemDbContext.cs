﻿namespace VoteSystem.Data
{
    using System.Data.Entity;

    using Microsoft.AspNet.Identity.EntityFramework;

    using VoteSystem.Data.Migrations;
    using VoteSystem.Data.Models;
    using System.Linq;
    using System;
    using VoteSystem.Data.Common.Models;

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