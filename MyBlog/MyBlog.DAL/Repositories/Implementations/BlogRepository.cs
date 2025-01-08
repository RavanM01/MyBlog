using MyBlog.Core.Entities;
using MyBlog.DAL.Context;
using MyBlog.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DAL.Repositories.Implementations
{
    public class BlogRepository:Repository<Blog>, IBlogRepository
    {
        public BlogRepository(AppDBContext dBContext) : base(dBContext) { }
    
    }
}
