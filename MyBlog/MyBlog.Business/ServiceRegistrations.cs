using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using MyBlog.Business.Services.Implementations;
using MyBlog.Business.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Business
{
    public static class ServiceRegistrations
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ServiceRegistrations));
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IUserService, UserService>();    
            services.AddScoped<IBlogService, BlogService>();
            services.AddControllers().AddFluentValidation(c => c.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));
        }
    }
}
