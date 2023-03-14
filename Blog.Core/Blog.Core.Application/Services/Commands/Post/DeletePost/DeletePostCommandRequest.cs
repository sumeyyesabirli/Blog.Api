using MediatR;
using Shared.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Application.Services.Commands.Post.DeletePost
{
    public class DeletePostCommandRequest : IRequest<IResult>
    {
        public Guid Id { get; set; }
    }
}
