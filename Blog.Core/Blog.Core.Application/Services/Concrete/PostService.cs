using AutoMapper;
using Blog.Core.Application.Repositories;
using Blog.Core.Application.Services.Abstract;
using Blog.Core.Domain.Entites;
using Blog.Core.RequestManager.Commands.Requests;
using Blog.Core.RequestManager.Queries.Requests;
using Blog.Core.RequestManager.Queries.Responses;
using Microsoft.AspNetCore.Mvc;
using Shared.Response;

namespace Blog.Core.Application.Services.Concrete
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
        private readonly ResponseItemManager _responseItemManager;

        public PostService(IPostRepository postRepository, IMapper mapper, ResponseItemManager responseItemManager)
        {
            _postRepository = postRepository;
            _mapper = mapper;
            _responseItemManager = responseItemManager;
        }

        public  async Task<ResponseItem> Add(InsertPostCommandRequestModel requestModel)
        {
            var manager = _responseItemManager;
            var mapPost = _mapper.Map<Post>(requestModel);
            var  addPost = _postRepository.Add(mapPost);

            if (await _postRepository.SaveAsync() < 1)
            {
                
                return manager.Eror();
            }
            await _postRepository.SaveAsync();
            return manager.Ok();
        }
        public async Task<ResponseItem> Update(UpdatePostCommandRequestModel requestModel)
        {
            var manager = _responseItemManager;
            var getAsync = await _postRepository.GetAsync(x => x.Id == requestModel.Id);

            try
            {
               var @null = getAsync == null;
            }
            catch (Exception)
            {

                return manager.Eror();
            }

            var mapPost = _mapper.Map<UpdatePostCommandRequestModel, Post>(requestModel, getAsync);
            var updatepost = _postRepository.Update(mapPost);            
            await _postRepository.SaveAsync();
            return manager.Ok();

        }
        public async Task<ResponseItem> Delete(DeletePostCommandRequestModel requestModel)
        {
            var manager = _responseItemManager;
            var getAsync = _postRepository.GetAsync(x => x.Id == requestModel.Id);
            var mapPost = _mapper.Map<Post>(requestModel);

            if (getAsync == null)
            {
                return manager.Eror();
            }

            var deletPost = await _postRepository.Delete(mapPost);

            if (await _postRepository.SaveAsync() < 1)
            {

                return manager.Eror();
            }
            await _postRepository.SaveAsync();
            return manager.Ok();

        }
        public async Task<ResponseItem<List<PostQueriResponseModel>>> GetAll(GetAllPostQueriRequestModel requestModel)
        {
            var manager =  _responseItemManager;
            var getAllpost = _postRepository.GetAll(x => x.Visible == true);
            var mapPost = _mapper.Map<List<PostQueriResponseModel>>(getAllpost);
            return manager.Ok(mapPost);
        }

        public async Task<ResponseItem<PostQueriResponseModel>> GetById(GetByIdPostQueriRequestModel requestModel)
        {
            var manager = _responseItemManager;
            var getAsync = await _postRepository.GetAsync(x => x.Id == requestModel.Id);              
            var getByIdpost = _postRepository.GetById(getAsync, requestModel.Id);
            var mapPost = _mapper.Map<PostQueriResponseModel>(getByIdpost);
            return manager.Ok(mapPost);
        }
    }
}
