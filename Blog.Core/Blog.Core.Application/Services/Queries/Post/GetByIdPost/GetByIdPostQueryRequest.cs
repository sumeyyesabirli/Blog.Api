using Blog.Core.Application.Services.Queries.Post.GetByIdPost;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Application.Services.Queries.Post.GetByIdPost
{
    public class GetByIdPostQueryRequest : IRequest<GetByIdPostQueryResponse>
    {
        public Guid Id { get; set; }
    }
}
