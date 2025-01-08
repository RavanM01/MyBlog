using Microsoft.Extensions.DependencyInjection;
using MyBlog.DAL.Repositories.Implementations;
using MyBlog.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DAL
{
    public static class DALServiceRegistrations
    {
        public static void AddDALServices(this IServiceCollection services)
        {
           services.AddScoped<ICategoryRepository,CategoryRepository>();
           services.AddScoped<IBlogRepository,BlogRepository>();
        }
    }
}
