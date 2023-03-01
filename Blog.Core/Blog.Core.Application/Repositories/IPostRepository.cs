using Blog.Core.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Application.Repositories
{
    public interface IPostRepository : IRepository<Post>
    {
    }
}
