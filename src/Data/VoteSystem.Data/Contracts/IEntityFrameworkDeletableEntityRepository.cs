using System.Linq;

namespace VoteSystem.Data.Contracts
{
    public interface IEntityFrameworkDeletableEntityRepository<TEntity> : IEntityFrameworkRepository<TEntity> 
        where TEntity : class
    {
        IQueryable<TEntity> AllWithDeleted();

        void HardDelete(TEntity entity);
    }
}
