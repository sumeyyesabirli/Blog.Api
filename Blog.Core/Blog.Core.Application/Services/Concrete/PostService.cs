using AutoMapper;
using Blog.Core.Application.Repositories;
using Blog.Core.Application.Services.Abstract;
using Blog.Core.Domain.Entites;
using Blog.Core.RequestManager.Commands.Requests;
using Blog.Core.RequestManager.Queries.Requests;
using Blog.Core.RequestManager.Queries.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Application.Services.Concrete
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public PostService(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Add(InsertPostRequestModel requestModel)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> Delete(DeletePostRequestModel requestModel)
        {
            throw new NotImplementedException();
        }

        public Task<List<PostResponseModel>> GetAll(GetAllPostRequestModel requestModel)
        {
            throw new NotImplementedException();
        }

        public Task<PostResponseModel> GetById(GetByIdPostRequestModel requestModel)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> Update(UpdatePostRequestModel requestModel)
        {
            throw new NotImplementedException();
        }
    }
}
