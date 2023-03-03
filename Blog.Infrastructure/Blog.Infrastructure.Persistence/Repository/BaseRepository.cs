using Blog.Core.Application.Repositories;
using Blog.Core.Domain.Entites;
using Blog.Infrastructure.Persistence.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace Blog.Infrastructure.Persistence.Repository
{
    public class BaseRepository<TEntity,IContext> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly BlogDbContext _context;

        public BaseRepository(BlogDbContext context)
        {
            _context = context;
        }

        public Task Add(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            return Task.FromResult(entity);            
        }
        public async Task<TEntity> Delete(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            return entity;
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, int skip = 0, int take = 0, params Expression<Func<TEntity, object>>[] includes)
        {
            return _context.Set<TEntity>();
        }

        public  async Task<TEntity> GetById(TEntity entity,Guid id)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(p => p.Id == id);
        }     
        public Task Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return Task.FromResult(entity);
        }
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            foreach (Expression<Func<TEntity, object>> include in includes)
            {
                query = query.Include(include);
            }
            return await query.AsNoTracking().AsQueryable().FirstOrDefaultAsync(expression);
        }
    }
}

