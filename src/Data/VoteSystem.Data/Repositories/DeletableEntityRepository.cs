using System;
using System.Data.Entity;
using System.Linq;
using VoteSystem.Data.Contracts;
using VoteSystem.Models.Common;

namespace VoteSystem.Data.Repositories
{
    public class DeletableEntityRepository<TEntity> :
        EntityFrameworkRepository<TEntity>, IDeletableEntityRepository<TEntity> where TEntity : class, IDeletableEntity
    {
        public DeletableEntityRepository(DbContext context)
            : base(context)
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
            entity.DeletedOn = DateTime.Now;

            var entry = this.Context.Entry(entity);

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
