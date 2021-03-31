
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace Attendleave.Erp.Core.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private const bool TrueExpression = true;
        protected readonly DbContext Context;
        protected DbSet<T> DbSet;
        public Repository(DbContext context)
        {
            Context = context;
            DbSet = Context.Set<T>();
        }

        public async Task<T> Get(params object[] keys)
        {
            return await DbSet.FindAsync(keys);
        }

        public async Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return await DbSet.FirstOrDefaultAsync(predicate);
        }
        public async Task<int> Max(Expression<Func<T, int>> predicate)
        {
            return await DbSet.MaxAsync(predicate);
        }
        public async Task<int> Count()
        {
            return await DbSet.CountAsync<T>();
        }

        //  public static int Count<TSource>();



        public async Task<IList<T>> Find(Expression<Func<T, bool>> predicate)
        {
            return await DbSet.Where(predicate).ToListAsync();
        }

        public async Task<IList<T>> Find(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            var query = DbSet.OfType<T>();
            query = includes.Aggregate(query, (current, property) => current.Include(property));
            return await query.Where(predicate).ToListAsync();
        }

        public IQueryable<T> FindQueryable(Expression<Func<T, bool>> predicate)
        {
            return  DbSet.Where(predicate).AsQueryable();         
        }
        public IQueryable<T> FindQueryable(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            var query = DbSet.OfType<T>();
            query = includes.Aggregate(query, (current, property) => current.Include(property));

            return query.Where(predicate).AsQueryable();
        }
        public async Task<IEnumerable<T>> FindQueryableAsyn(IQueryable<T> myQueryable)
        {
            return await myQueryable.ToListAsync();
        }
        public async Task<IEnumerable<T>> FindBy(Expression<Func<T, bool>> predicate)
        {
            var query = DbSet.Where(predicate).AsQueryable();
            return await query.ToListAsync();
        }

        public async Task<T> SingleOrDefault(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            var result = await Find(predicate, includes);
            return result.SingleOrDefault();
        }
        public async Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            var result = await Find(predicate, includes);
            return result.FirstOrDefault();
        }

        public async Task<IList<T>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public IQueryable<T> GetAll2()
        {
            return DbSet;
        }
        public async Task<IList<T>> GetAll(params Expression<Func<T, object>>[] includes)
        {
            return await Find(x => TrueExpression, includes);
        }

        public T Add(T newEntity)
        {
            return DbSet.Add(newEntity).Entity;
        }
        public void AddRange(IEnumerable<T> entities)
        {
            DbSet.AddRange(entities);
        }
        public void Update(T entity)
        {
            var key = GetKeyValue(entity);

            Update(entity, key);
        }

        public void Update(T entity, object key)
        {
            var originalEntity = DbSet.Find(key);

            Update(originalEntity, entity);
        }

        public void Update(T originalEntity, T newEntity)
        {
            Context.Entry(originalEntity).CurrentValues.SetValues(newEntity);
        }

        public void UpdateRange( IEnumerable<T> newEntitie)
        {
            Context.UpdateRange(newEntitie);
        }

        public void Remove(T entity)
        {
            DbSet.Remove(entity);
        }

        public void Remove(Expression<Func<T, bool>> predicate)
        {
            var objects = Find(predicate);
            foreach (var obj in objects.Result)
            {
                DbSet.Remove(obj);
            }
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            DbSet.RemoveRange(entities);
        }

        public string GetKeyField(Type type)
        {
            var allProperties = type.GetProperties();

            var keyProperty = allProperties.SingleOrDefault(p => p.IsDefined(typeof(KeyAttribute)));

            return keyProperty?.Name;
        }

        public int GetNextKeySequence()
        {
            var query = DbSet.OfType<T>();
            var theLast = query.LastOrDefault();
            if (theLast == null) return 1;
            var key = theLast.GetType().GetProperties().FirstOrDefault(
                    p => p.GetCustomAttributes(typeof(KeyAttribute), true).Length != 0);
            if (key != null)
            {
                var keyValue = key.GetValue(theLast, null).ToString();
                int.TryParse(keyValue, out int valueResult);
                return valueResult;
            }

            return 0;
        }

        public object GetKeyValue(T t)
        {
            var key =
                typeof(T).GetProperties().FirstOrDefault(
                    p => p.GetCustomAttributes(typeof(KeyAttribute), true).Length != 0);
            return key?.GetValue(t, null);
        }
        

        public async Task<bool> Contains(Expression<Func<T, bool>> predicate)
        {
            return await DbSet.AnyAsync(predicate);
        }

        public async Task<TResult> FirstOrDefaultSelectorAsync<TResult>(Expression<Func<T, TResult>> selector,
                                      Expression<Func<T, bool>> predicate = null,
                                      Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                      Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
                                      bool disableTracking = true)
        {
            IQueryable<T> query = DbSet;
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (orderBy != null)
            {
                return await orderBy(query).Select(selector).FirstOrDefaultAsync();
            }
            else
            {
                return await query.Select(selector).FirstOrDefaultAsync();
            }
        }
        public async Task<T> FirstOrDefaultThenIncludeAsync(
                                           Expression<Func<T, bool>> predicate = null,
                                           Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                           Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
                                           bool disableTracking = true)
        {
            IQueryable<T> query = DbSet;
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            return await query.FirstOrDefaultAsync();
        }
        public IQueryable<T> FindThenInclude(
                                    Expression<Func<T, bool>> predicate = null,
                                    Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                    Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
                                    bool disableTracking = true)
        {
            IQueryable<T> query = DbSet;
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }
            if (include != null)
            {
                query = include(query);
            }
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            if (orderBy != null)
            {
                query = orderBy(query);
            }
            return query.AsQueryable();
        }
        public async Task<IQueryable<TResult>> FindSelectorAsync<TResult>(Expression<Func<T, TResult>> selector,
                                     Expression<Func<T, bool>> predicate = null,
                                     Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                     Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
                                     bool disableTracking = true)
        {
            IQueryable<T> query = DbSet;
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (orderBy != null)
            {
                return orderBy(query).Select(selector);
            }
            else
            {
                return query.Select(selector);
            }
        }
        public IQueryable<TResult> FindSelectorQueryable<TResult>(IQueryable<T> myQueryable,
                                   Expression<Func<T, TResult>> selector)
        {
            return myQueryable.Select(selector);
        }

        public async Task<TResult> FirestOrDefualtSelectorAsync<TResult>(Expression<Func<T, TResult>> selector,
                                 Expression<Func<T, bool>> predicate = null,
                                 Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = DbSet;
            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            return await query.Select(selector).FirstOrDefaultAsync();
        }
    }
}
