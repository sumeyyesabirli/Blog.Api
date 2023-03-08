using MediatR;

namespace Blog.Core.Application.Services.Queries.Post.GetAllPost
{
    public class GetAllPostQueryRequest : IRequest<List<GetAllPostQueryResponse>>
    {
       
    }
}
