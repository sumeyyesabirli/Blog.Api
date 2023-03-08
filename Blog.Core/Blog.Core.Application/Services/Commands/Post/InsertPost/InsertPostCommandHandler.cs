using AutoMapper;
using Blog.Core.Application.Services.Commands.Post.InsertPost;
using Blog.Core.Application.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Core.Application.Services.Commands.Post.InsertPost
{
    public class InsertPostCommandHandler : IRequestHandler<InsertPostCommandRequest, InsertPostCommandResponse>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public InsertPostCommandHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public  async Task<InsertPostCommandResponse> Handle(InsertPostCommandRequest request, CancellationToken cancellationToken)
        {
            var mapPost = _mapper.Map<Domain.Entites.Post>(request);
            var addPost = _postRepository.Add(mapPost);
           

            if (await _postRepository.SaveAsync() < 1)
            {
                
                var result = new ObjectResult(new { error = "Veri Eklenemedi" })
                {
                    StatusCode = 500
                };
            }

            var post = _mapper.Map<InsertPostCommandResponse>(addPost);         

            return await Task.FromResult(post);

        }
    }
}
