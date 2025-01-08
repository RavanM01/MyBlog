using AutoMapper;
using MyBlog.Business.DTOs.Blog;
using MyBlog.Business.Services.Interfaces;
using MyBlog.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Business.Services.Implementations
{
    public class BlogService : IBlogService
    {
        IBlogRepository _rep;
        IMapper _mapper;


        public BlogService(IBlogRepository rep, IMapper mapper)
        {
            _rep = rep;
            _mapper = mapper;
        }

        public List<GetBlogDto> GetAll()
        {
            var Blogs =_rep.GetAll("Author");
            var returnBlogs = _mapper.Map<List<GetBlogDto>>(Blogs);

            return returnBlogs;
        }
    }
}
