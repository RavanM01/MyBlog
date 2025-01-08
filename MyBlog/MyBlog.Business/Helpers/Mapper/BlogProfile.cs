using AutoMapper;
using MyBlog.Business.DTOs.Blog;
using MyBlog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Business.Helpers.Mapper
{
    public class BlogProfile:Profile
    {
        public BlogProfile()
        {
            CreateMap<GetBlogDto,Blog>().ReverseMap();
            CreateMap<AuthorGetDto,AppUser>().ReverseMap();
        }
    }
}
