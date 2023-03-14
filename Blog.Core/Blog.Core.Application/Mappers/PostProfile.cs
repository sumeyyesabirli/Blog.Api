using AutoMapper;
using Blog.Core.Application.Services.Commands.Post.InsertPost;
using Blog.Core.Application.Services.Commands.Post.UpdatePost;
using Blog.Core.Application.Services.Queries.Post.GetAllPost;
using Blog.Core.Application.Services.Queries.Post.GetByIdPost;
using Blog.Core.Domain.Entites;

namespace Blog.Core.Application.Mappers
{
    public class PostProfile: Profile
    {
        public PostProfile()
        {
            CreateMap<Post, GetByIdPostQueryResponse>();
            CreateMap<Post, GetAllPostQueryResponse>();
            CreateMap<Post, UpdatePostCommandRequest>().ReverseMap();
            CreateMap<Post,InsertPostCommandRequest>();
            CreateMap<InsertPostCommandRequest, Post>().ReverseMap();
            CreateMap<InsertPostCommandResponse, Post>().ReverseMap();
            CreateMap<Post, InsertPostCommandResponse>().ReverseMap();
            CreateMap<UpdatePostCommandRequest, Post>();
            CreateMap<UpdatePostCommandResponse, Post>().ReverseMap();
        }
    }
}
