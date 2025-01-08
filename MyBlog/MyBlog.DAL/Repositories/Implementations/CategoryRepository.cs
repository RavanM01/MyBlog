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
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDBContext dBContext) : base(dBContext) { }
    }
}
