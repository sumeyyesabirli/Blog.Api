using Blog.Core.RequestManager.Commands.Requests;
using Blog.Core.RequestManager.Queries.Requests;
using Blog.Core.RequestManager.Queries.Responses;
using Blog.Infrastructure.Persistence.Contexts;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Controller;
using Shared.Response;

namespace Blog.Presentation.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : BaseController
    {
        public PostController(IClientFactory clientFactory, IHttpContextAccessor httpContextAccessor) : base(clientFactory, httpContextAccessor)
        {
        }

        [HttpPost]
        public IActionResult Insert(InsertPostCommandRequestModel request, CancellationToken cancellationToken)
        {
            return CreateActionResultInstance(CustomRequestClient<InsertPostCommandRequestModel, ResponseItem>(request, cancellationToken).GetAwaiter().GetResult().Message);
        }
        [HttpPut]
        public IActionResult Update([FromBody] UpdatePostCommandRequestModel request, CancellationToken cancellationToken)
        {
            return CreateActionResultInstance(CustomRequestClient<UpdatePostCommandRequestModel, ResponseItem>(request, cancellationToken).GetAwaiter().GetResult().Message);
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete([FromRoute] Guid Id, CancellationToken cancellationToken)
        {
            return CreateActionResultInstance(CustomRequestClient<DeletePostCommandRequestModel, ResponseItem>(new DeletePostCommandRequestModel { Id = Id }, cancellationToken).GetAwaiter().GetResult().Message);
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery] GetAllPostQueriRequestModel requestModel, CancellationToken cancellationToken)
        {
            return CreateActionResultInstance(CustomRequestClient<GetAllPostQueriRequestModel, ResponseItem<List<PostQueriResponseModel>>>(new GetAllPostQueriRequestModel(), cancellationToken).GetAwaiter().GetResult().Message);
        }
        [HttpGet("{Id}")]
        public IActionResult GetById([FromRoute] GetByIdPostQueriRequestModel request, CancellationToken cancellationToken)
        {
            return CreateActionResultInstance(CustomRequestClient<GetByIdPostQueriRequestModel, ResponseItem<PostQueriResponseModel>>(request, cancellationToken).GetAwaiter().GetResult().Message);
        }        
    }
}
