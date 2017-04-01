using System;
using System.Data.Entity;
using System.Linq;

using VoteSystem.Data.Contracts;

namespace VoteSystem.Data.Repositories
{
    public class EntityFrameworkRepository<TEntity> : IEntityFrameworkRepository<TEntity> 
        where TEntity : class
    {
        public EntityFrameworkRepository(IVoteSystemDbContext voteSystemDbContext)
        {
            if (voteSystemDbContext == null)
            {
                throw new ArgumentNullException(nameof(voteSystemDbContext));
            }

            this.VoteSystemDbContext = voteSystemDbContext;
            this.DbSet = this.VoteSystemDbContext.Set<TEntity>();
        }

        protected IDbSet<TEntity> DbSet { get; set; }
        protected IVoteSystemDbContext VoteSystemDbContext { get; set; }

        public virtual IQueryable<TEntity> All()
        {
            return this.DbSet.AsQueryable();
        }

        public virtual TEntity GetById(object id)
        {
            return this.DbSet.Find(id);
        }

        public virtual void Add(TEntity entity)
        {
            var entry = this.VoteSystemDbContext.Entry(entity);

            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Added;
            }
            else
            {
                this.DbSet.Add(entity);
            }
        }

        public virtual void Delete(TEntity entity)
        {
            var entry = this.VoteSystemDbContext.Entry(entity);

            if (entry.State != EntityState.Deleted)
            {
                entry.State = EntityState.Deleted;
            }
            else
            {
                this.DbSet.Attach(entity);
                this.DbSet.Remove(entity);
            }
        }

        public virtual void Update(TEntity entity)
        {
            var entry = this.VoteSystemDbContext.Entry(entity);

            if (entry.State == EntityState.Detached)
            {
                this.DbSet.Attach(entity);
            }

            entry.State = EntityState.Modified;
        }
    }
}
