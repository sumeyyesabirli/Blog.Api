using MediatR;

namespace Blog.Core.Application.Services.Queries.Post.GetByIdPost
{
    public class GetByIdPostQueryRequest : IRequest<GetByIdPostQueryResponse>
    {
        public Guid Id { get; set; }
    }
}
