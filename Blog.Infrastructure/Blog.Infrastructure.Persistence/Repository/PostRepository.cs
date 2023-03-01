using Blog.Core.Application.Repositories;
using Blog.Core.Domain.Entites;
using Blog.Infrastructure.Persistence.Contexts;

namespace Blog.Infrastructure.Persistence.Repository
{
    public class PostRepository : BaseRepository<Post,BlogDbContext>, IPostRepository
    {
        public PostRepository(BlogDbContext context):base(context)
        {

        }
    }
}
