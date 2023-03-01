using Blog.Core.Domain.Entites;

namespace Blog.Core.Application.Repositories
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task Add(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(Guid id);
        Task<TEntity> GetById(Guid id);
        IQueryable<TEntity> GetAll();
    }
}
