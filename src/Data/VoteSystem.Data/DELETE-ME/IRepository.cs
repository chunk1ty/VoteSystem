using System;
using System.Linq;
using System.Linq.Expressions;

namespace VoteSystem.Data.Ef.DELETE_ME
{
    public interface IRepository<T> where T : class
    {
        T GetById(object id);

        IQueryable<T> All();

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
