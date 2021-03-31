using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Attendleave.Erp.Core.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<T> Get(params object[] keys);
        Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate);
        Task<int> Count();
        Task<int> Max(Expression<Func<T, int>> predicate);
        Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
        Task<T> SingleOrDefault(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
        Task<IList<T>> GetAll();
        IQueryable<T> GetAll2();
        Task<IList<T>> GetAll(params Expression<Func<T, object>>[] includes);
        Task<IList<T>> Find(Expression<Func<T, bool>> predicate);
        Task<IList<T>> Find(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
        IQueryable<T> FindQueryable(Expression<Func<T, bool>> predicate);
        IQueryable<T> FindQueryable(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
        Task<IEnumerable<T>> FindQueryableAsyn(IQueryable<T> myQueryable);
        Task<IEnumerable<T>> FindBy(Expression<Func<T, bool>> predicate);
        Task<bool> Contains(Expression<Func<T, bool>> predicate);
        T Add(T newEntity);
        void AddRange(IEnumerable<T> entities);
        void Update(T entity);
        void Update(T entity, object key);
        void Update(T originalEntity, T newEntity);
        void UpdateRange(IEnumerable<T> newEntitie);
        void Remove(T entity);
        void Remove(Expression<Func<T, bool>> predicate);
        void RemoveRange(IEnumerable<T> entities);
        object GetKeyValue(T t);
        string GetKeyField(Type type);
        int GetNextKeySequence();
        Task<TResult> FirstOrDefaultSelectorAsync<TResult>(Expression<Func<T, TResult>> selector,
                                     Expression<Func<T, bool>> predicate = null,
                                     Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                     Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
                                     bool disableTracking = true);

        Task<T> FirstOrDefaultThenIncludeAsync(
                                    Expression<Func<T, bool>> predicate = null,
                                    Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                    Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
                                    bool disableTracking = true);
        Task<IQueryable<TResult>> FindSelectorAsync<TResult>(Expression<Func<T, TResult>> selector,
                                     Expression<Func<T, bool>> predicate = null,
                                     Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                     Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
                                     bool disableTracking = true);
        IQueryable<T> FindThenInclude(
                                    Expression<Func<T, bool>> predicate = null,
                                    Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                    Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
                                    bool disableTracking = true);
        IQueryable<TResult> FindSelectorQueryable<TResult>(IQueryable<T> myQueryable,
                                   Expression<Func<T, TResult>> selector);
        Task<TResult> FirestOrDefualtSelectorAsync<TResult>(Expression<Func<T, TResult>> selector,
                                 Expression<Func<T, bool>> predicate = null,
                                 Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
    }
}
