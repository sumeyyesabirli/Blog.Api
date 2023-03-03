using Blog.Core.RequestManager.Commands.Requests;
using Blog.Core.RequestManager.Queries.Requests;
using Blog.Core.RequestManager.Queries.Responses;
using Shared;

namespace Blog.Core.Application.Services.Abstract
{
    public interface IPostService
    {
        Task<ResponseItem> Add(InsertPostCommandRequestModel requestModel);
        Task<ResponseItem> Update(UpdatePostCommandRequestModel requestModel);
        Task<ResponseItem> Delete(DeletePostCommandRequestModel requestModel);
        Task<ResponseItem<PostQueriResponseModel>> GetById(GetByIdPostQueriRequestModel requestModel);
        Task<ResponseItem<List<PostQueriResponseModel>>> GetAll(GetAllPostQueriRequestModel requestModel);
    }
}
