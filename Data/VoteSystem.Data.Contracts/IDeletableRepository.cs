using System.Linq;

namespace VoteSystem.Data.Contracts
{
    public interface IDeletableRepository<TEntity> : IRepository<TEntity> 
        where TEntity : class
    {
        IQueryable<TEntity> AllWithDeleted();

        void HardDelete(TEntity entity);
    }
}
