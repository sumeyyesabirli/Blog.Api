using Blog.Core.Application.Repositories;
using Blog.Core.Domain.Entites;
using Blog.Infrastructure.Persistence.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

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
            _context.SaveChanges();
            return Task.FromResult(entity);
        }

        public async Task Delete(Guid id)
        {

            _context.Entry(id).State = EntityState.Deleted;
            //var entity = await GetById(id);
            //_context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();                      
        }

        public IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>();
        }

        public  async Task<TEntity> GetById(Guid id)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(p => p.Id == id);
        }

        public Task Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChangesAsync();
            return Task.FromResult(entity);
        }
    }
}

