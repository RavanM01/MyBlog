using AutoMapper;
using MyBlog.Business.DTOs.Category;
using MyBlog.Business.DTOs.User;
using MyBlog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Business.Helpers.Mapper
{
    public class AutoMapper:Profile
    {
        public AutoMapper() {
            CreateMap<GetCategoryDto, Category>().ReverseMap();
            CreateMap<GetAllCategoryDto, Category>().ReverseMap();
            CreateMap<CreateCategoryDto, Category>().ReverseMap();
            CreateMap<UpdateCategoryDto, GetCategoryDto>().ReverseMap();
            CreateMap<RegisterDto,AppUser>().ReverseMap();
        }
    }
}
