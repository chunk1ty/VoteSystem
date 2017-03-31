using System.Linq;

namespace VoteSystem.Data.Contracts
{
    public interface IDeletableEntityRepository<TEntity> : IEntityFrameworkRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> AllWithDeleted();

        void HardDelete(TEntity entity);
    }
}
