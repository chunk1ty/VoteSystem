namespace VoteSystem.Data.Common
{
    using System.Linq;

    public interface IDeletableEntityRepository<T> : IDbGenericRepository<T> where T : class
    {
        IQueryable<T> AllWithDeleted();

        void HardDelete(T entity);
    }
}
