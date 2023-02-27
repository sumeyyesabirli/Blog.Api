﻿using Blog.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Diagnostics;

namespace Blog.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BlogDbContext>(x =>
            {
                x.UseNpgsql(configuration.GetConnectionString("BlogDbContext"))
                    .LogTo(x => Debug.WriteLine(x));
                    x.EnableSensitiveDataLogging();
            });
            services.TryAddScoped<DbContext, BlogDbContext>();
        }
    }
}
