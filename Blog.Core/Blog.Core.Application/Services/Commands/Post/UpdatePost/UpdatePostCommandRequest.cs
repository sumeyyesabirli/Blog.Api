using MediatR;

namespace Blog.Core.Application.Services.Commands.Post.UpdatePost
{
    public class UpdatePostCommandRequest : IRequest<UpdatePostCommandResponse>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Context { get; set; }
        public string Sunmary { get; set; }
        public string UrlHandle { get; set; }
        public string FeaturedImageUrl { get; set; }
        public string Author { get; set; }
        public bool Visible { get; set; }
        public DateTime PulisDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
