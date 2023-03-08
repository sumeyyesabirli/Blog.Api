using AutoMapper;
using Blog.Core.Application.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace Blog.Core.Application.Services.Commands.Post.UpdatePost
{
    public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommandRequest, UpdatePostCommandResponse>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public UpdatePostCommandHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<UpdatePostCommandResponse> Handle(UpdatePostCommandRequest request, CancellationToken cancellationToken)
        {
            var getAsync = _postRepository.GetAsync(x => x.Id == request.Id);

            if (getAsync==null)
            {
                var result = new ObjectResult(new { error = "Id boş gelemez" })
                {
                    StatusCode = 500
                };
            }
            var map = _mapper.Map<UpdatePostCommandRequest, Domain.Entites.Post>(request, getAsync);
            var updatePost = _postRepository.Update(map);
            var updateMap = _mapper.Map<UpdatePostCommandResponse>(updatePost);
            await _postRepository.SaveAsync();                 
        
            
            return await Task.FromResult(updateMap);
        }
    }
}
