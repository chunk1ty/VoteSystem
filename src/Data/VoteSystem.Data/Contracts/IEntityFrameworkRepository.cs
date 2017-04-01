using System.Linq;

namespace VoteSystem.Data.Contracts
{
    public interface IEntityFrameworkRepository<TEntity>
        where TEntity : class
    {
        IQueryable<TEntity> All();

        TEntity GetById(object id);

        void Add(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);
    }
}
