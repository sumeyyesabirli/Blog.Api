using Blog.Core.Domain.Entites;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace Blog.Core.Application.Repositories
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        TEntity Delete(TEntity entity);
        Task<TEntity> GetById(TEntity entity, Guid id);
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, int skip = 0, int take = 0, params Expression<Func<TEntity, object>>[] includes);
        Task<int> SaveAsync();
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, object>>[] includes);
    }
}
