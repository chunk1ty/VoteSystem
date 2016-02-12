namespace VoteSystem.Data.Common
{
    using System;
    using System.Linq;

    using VoteSystem.Data.Common.Models;

    // TODO: Why BaseModel<int> instead BaseModel<TKey>?
    public interface IDbGenericRepository<T> : IDbGenericRepository<T, int>
       where T : BaseModel<int>
    {
    }

    public interface IDbGenericRepository<T, in TKey> : IDisposable where T : BaseModel<TKey>
    {
        IQueryable<T> All();

        IQueryable<T> AllWithDeleted();

        T GetById(TKey id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void HardDelete(T entity);

        void SaveChanges();
    }
}
