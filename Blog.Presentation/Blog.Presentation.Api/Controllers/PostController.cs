using Blog.Infrastructure.Persistence.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Presentation.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]    
    public class PostController : ControllerBase
    {
        private readonly BlogDbContext _context;
        public PostController(BlogDbContext context)
        {
            this._context = context;
        }
    }
}
