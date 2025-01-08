using MyBlog.Business.DTOs.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Business.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<GetCategoryDto> CreateAsync(CreateCategoryDto dto);
        Task<GetCategoryDto> GetById(int id);
        List<GetCategoryDto> GetAll();
        Task Update(UpdateCategoryDto dto);
        Task Delete(int id);
        Task SoftDelete(int id);

    }
}
