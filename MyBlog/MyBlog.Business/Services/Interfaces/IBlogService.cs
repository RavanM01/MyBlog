using MyBlog.Business.DTOs.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Business.Services.Interfaces
{
    public interface IBlogService
    {
        List<GetBlogDto> GetAll();
        Task<GetCategoryDto> CreateAsync(CreateCategoryDto dto);
        
    }
}
