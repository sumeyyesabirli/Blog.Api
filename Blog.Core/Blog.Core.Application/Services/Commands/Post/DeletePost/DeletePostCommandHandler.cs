using AutoMapper;
using Blog.Core.Application.Services.Commands.Post.DeletePost;
using Blog.Core.Application.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Core.Application.Services.Commands.Post.DeletePost
{
    public class DeletePostCommandHandler : IRequestHandler<DeletePostCommandRequest,bool>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public DeletePostCommandHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(DeletePostCommandRequest request, CancellationToken cancellationToken)
        {
            var getAsync = await _postRepository.GetAsync(x => x.Id == request.Id);
          
            if (getAsync == null)
            {
                var result = new ObjectResult(new { error = "Id boş gelemez" })
                {
                    StatusCode = 500
                };
            }
            var deletPost =  await _postRepository.Delete(getAsync);

            if (await _postRepository.SaveAsync() < 1)
            {

                var result = new ObjectResult(new { error = "Veri Silinemedi" })
                {
                    StatusCode = 500
                };
            }      

            return true;
        }
    }
}
