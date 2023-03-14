using AutoMapper;
using Blog.Core.Application.Mappers;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Blog.Core.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddAutoMapper(assembly);
            services.AddMediatR(assembly);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new PostProfile());
            });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }       
    }
}
