using AutoMapper;
using Blog.Core.Application.Services.Queries.Post.GetByIdPost;
using Blog.Core.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Application.Services.Queries.Post.GetByIdPost
{
    public class GetByIdPostQueryHandler : IRequestHandler<GetByIdPostQueryRequest, GetByIdPostQueryResponse>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public GetByIdPostQueryHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdPostQueryResponse> Handle(GetByIdPostQueryRequest request, CancellationToken cancellationToken)
        {
            var getId = await _postRepository.GetAsync(x => x.Id == request.Id);
            var mapPost = _mapper.Map<GetByIdPostQueryResponse>(getId);
            return await Task.FromResult(mapPost);
        }
    }
}
