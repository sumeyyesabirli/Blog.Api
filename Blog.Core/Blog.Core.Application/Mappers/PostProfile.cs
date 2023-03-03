using AutoMapper;
using Blog.Core.Domain.Entites;
using Blog.Core.RequestManager.Commands.Requests;
using Blog.Core.RequestManager.Queries.Responses;

namespace Blog.Core.Application.Mappers
{
    public class PostProfile: Profile
    {
        public PostProfile()
        {
            CreateMap<InsertPostCommandRequestModel, Post>();
            CreateMap<UpdatePostCommandRequestModel, Post>();
            CreateMap<Post, PostQueriResponseModel>();
        }
    }
}
