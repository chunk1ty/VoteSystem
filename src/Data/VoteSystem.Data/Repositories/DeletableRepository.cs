using System;
using System.Data.Entity;
using System.Linq;

using VoteSystem.Data.Contracts;
using VoteSystem.Data.Entities.Contracts;

namespace VoteSystem.Data.Repositories
{
    public class DeletableRepository<TEntity> : Repository<TEntity>, IDeletableRepository<TEntity> 
        where TEntity : class, IDeletableEntity
    {
        public DeletableRepository(IVoteSystemDbContext voteSystemDbContext)
            : base(voteSystemDbContext)
        {
        }
     
        public override IQueryable<TEntity> All()
        {
            return base.All().Where(x => !x.IsDeleted);
        }

        public IQueryable<TEntity> AllWithDeleted()
        {
            return base.All();
        }

        public override void Delete(TEntity entity)
        {
            entity.IsDeleted = true;
            entity.DeletedOn = DateTime.UtcNow;

            var entry = base.VoteSystemDbContext.Entry(entity);

            if (entry.State == EntityState.Detached)
            {
                this.DbSet.Attach(entity);
            }

            entry.State = EntityState.Modified;
        }

        public void HardDelete(TEntity entity)
        {
            base.Delete(entity);
        }
    }
}
