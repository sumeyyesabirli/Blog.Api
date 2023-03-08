using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Application.Services.Commands.Post.DeletePost
{
    public class DeletePostCommandRequest : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
