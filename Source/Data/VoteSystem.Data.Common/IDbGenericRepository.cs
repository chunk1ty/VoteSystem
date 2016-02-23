namespace VoteSystem.Data.Common
{
    using System;
    using System.Linq;

    using VoteSystem.Data.Common.Models;

    public interface IDbGenericRepository<T> : IDisposable where T : class
    {
        IQueryable<T> All();

        T GetById(object id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        T Attach(T entity);

        void Detach(T entity);

        void SaveChanges();
    }
}
