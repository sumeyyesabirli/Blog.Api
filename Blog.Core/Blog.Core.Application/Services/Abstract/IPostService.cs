using Blog.Core.RequestManager.Commands.Requests;
using Blog.Core.RequestManager.Queries.Requests;
using Blog.Core.RequestManager.Queries.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Core.Application.Services.Abstract
{
    public interface IPostService
    {
        Task<IActionResult> Add(InsertPostRequestModel requestModel);
        Task<IActionResult> Update(UpdatePostRequestModel requestModel);
        Task<IActionResult> Delete(DeletePostRequestModel requestModel);
       Task<PostResponseModel> GetById(GetByIdPostRequestModel requestModel);
       Task<List<PostResponseModel>> GetAll(GetAllPostRequestModel requestModel);
    }
}
