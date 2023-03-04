using Blog.Core.Application.Repositories;
using Blog.Core.Application.Services.Abstract;
using Blog.Core.Application.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Blog.Core.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddTransient<IPostService, PostService>().Reverse();
        }
    }
}
