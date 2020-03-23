using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ProFit.Core.Shared.Entities;
using ProFit.Core.Shared.Interfaces.Repository;

namespace ProFit.Infra.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly DataContext DbContext;

        public Repository(DataContext dbContext)
        {
            DbContext = dbContext;
        }

        public T Create(T objeto)
        {
            DbContext.Set<T>().Add(objeto);
            return objeto;
        }

        public T Update(T objeto)
        {
            DbContext.Entry(objeto).State = EntityState.Modified;
            return objeto;
        }

        public void Delete(int id)
        {
            var obj = DbContext.Set<T>().FirstOrDefault(x => x.Id == id);

            if (obj == null)
                return;

            DbContext.Set<T>().Remove(obj);
        }

        public void Inactivate(T entity)
        {
            DbContext.Entry(entity).Property(x => x.Active).IsModified = true;
        }

        public T GetById(int id)
        {
            return DbContext.Set<T>().AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public virtual T GetByIdWithIncludes(int id, bool asNoTracking = true, params Expression<Func<T, object>>[] includeExpressions)
        {
            IQueryable<T> query = DbContext.Set<T>();
            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }

            query = includeExpressions.Aggregate(query, (current, includeExpression) => current.Include(includeExpression));

            return query.FirstOrDefault(t => t.Id == id);
        }

        public IList<T> GetAll()
        {
            return DbContext.Set<T>().ToList();
        }

        public virtual IEnumerable<T> GetAllWithIncludes(Expression<Func<T, object>> ordenacao = null, params Expression<Func<T, object>>[] includeExpressions)
        {
            var query = DbContext.Set<T>().AsNoTracking();
            if (ordenacao != null)
            {
                query = query.OrderBy(ordenacao);
            }

            query = includeExpressions.Where(includeExpression => includeExpression != null).Aggregate(query,
                (current, includeExpression) => current.Include(includeExpression));

            return query.ToList();
        }
    }
}
