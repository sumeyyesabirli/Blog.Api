using AutoMapper;
using Blog.Core.Application.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.Constants;
using Shared.Result;

namespace Blog.Core.Application.Services.Commands.Post.DeletePost
{
    public class DeletePostCommandHandler : IRequestHandler<DeletePostCommandRequest, IResult>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public DeletePostCommandHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<IResult> Handle(DeletePostCommandRequest request, CancellationToken cancellationToken)
        {
            var  getId = await _postRepository.GetAsync(x => x.Id == request.Id);
          
            if (getId == null)
            {
                return await Task.FromResult<IResult>(new ErrorResult(ResultMessages.IdErorPostDelete));
             
            }
            var deletPost =   _postRepository.Delete(getId);

            if (await _postRepository.SaveAsync() < 1)
            {

                return await Task.FromResult<IResult>(new ErrorResult(ResultMessages.ErorPostDelete));
            }

            return await Task.FromResult<IResult>(new SuccessResult(ResultMessages.SuccessPostDelete));
        }
    }
}
