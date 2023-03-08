using AutoMapper;
using Blog.Core.Application.Services.Queries.Post.GetAllPost;
using Blog.Core.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Application.Services.Queries.Post.GetAllPost
{
    public class GetAllPostQueryHandler : IRequestHandler<GetAllPostQueryRequest, List<GetAllPostQueryResponse>>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public GetAllPostQueryHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public Task<List<GetAllPostQueryResponse>> Handle(GetAllPostQueryRequest request, CancellationToken cancellationToken)
        {
            var getAll = _postRepository.GetAll(x => x.Visible == true);
            var map = _mapper.Map<List<GetAllPostQueryResponse>>(getAll);
            return Task.FromResult(map);
        }
    }
}
