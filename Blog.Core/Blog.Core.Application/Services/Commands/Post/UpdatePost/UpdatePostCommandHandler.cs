using AutoMapper;
using Blog.Core.Application.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.Constants;
using Shared.Result;

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

        public  Task<UpdatePostCommandResponse> Handle(UpdatePostCommandRequest request, CancellationToken cancellationToken)
        {
            var getId =  _postRepository.GetAsync(x => x.Id == request.Id);

            if (getId == null)
            {
                new ErrorResult(ResultMessages.IdErorPostDelete);
            }
            var map =   _mapper.Map<Domain.Entites.Post>(request);
            var updatePost =  _postRepository.Update(map);
            var mapProduct = _mapper.Map<UpdatePostCommandResponse>(updatePost);

             _postRepository.SaveAsync();                 
        
            
            return  Task.FromResult(mapProduct);
        }
    }
}
