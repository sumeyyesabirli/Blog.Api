using Blog.Core.Application.Services.Commands.Post.DeletePost;
using Blog.Core.Application.Services.Commands.Post.InsertPost;
using Blog.Core.Application.Services.Commands.Post.UpdatePost;
using Blog.Core.Application.Services.Queries.Post.GetAllPost;
using Blog.Core.Application.Services.Queries.Post.GetByIdPost;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Presentation.Api.Controllers
{
    namespace Blog.Presentation.Api.Controllers
    {
        [ApiController]
        [Route("api/[controller]")]
        public class PostsController : ControllerBase
        {
            private readonly IMediator _mediator;
            

            public PostsController(IMediator mediator)
            {
                _mediator = mediator;
            }

            [HttpPost]
            public async Task<IActionResult> Add([FromBody] InsertPostCommandRequest request)
               => Ok(await _mediator.Send(request));

            [HttpPut("{id}")]
            public async Task<IActionResult> Update(UpdatePostCommandRequest request)
                => Ok(await _mediator.Send(request));


            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(Guid id) =>
                Ok(await _mediator.Send(new DeletePostCommandRequest { Id = id }));


            [HttpGet("{id}")]
            public async Task<IActionResult> GetById(Guid id) 
                => Ok(await _mediator.Send(new GetByIdPostQueryRequest { Id = id }));

            [HttpGet]
            public async Task<IActionResult> GetAll([FromQuery] GetAllPostQueryRequest requestModel)
               => Ok(await _mediator.Send(new GetAllPostQueryRequest()));

        }
    }
}
