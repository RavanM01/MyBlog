using AutoMapper;
using MyBlog.Business.DTOs.Category;
using MyBlog.Business.Helpers.Exceptions.Category;
using MyBlog.Business.Helpers.Exceptions.Common;
using MyBlog.Business.Services.Interfaces;
using MyBlog.Core.Entities;
using MyBlog.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Business.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        readonly ICategoryRepository _repo;
        readonly IMapper _mapper;

        public CategoryService(IMapper mapper, ICategoryRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public async Task<GetCategoryDto> CreateAsync(CreateCategoryDto dto)
        {
            if (await _repo.IsExsist(x => x.Name == dto.Name))
            {
                throw new CategoryNameExsistException();
            }
            var model = _mapper.Map<Category>(dto);
            var newModel = await _repo.Create(model);
            await _repo.SaveChangesAsync();
            return _mapper.Map<GetCategoryDto>(newModel);
        }


        public List<GetCategoryDto> GetAll()
        {
            List<GetCategoryDto> dtos = new();
            var datas = _repo.GetAll();
            foreach (var data in datas)
            {
                GetCategoryDto dto = _mapper.Map<GetCategoryDto>(data);
                dtos.Add(dto);
            }

        return dtos;
        }

        public async Task<GetCategoryDto> GetById(int id)
        {
            if (id <= 0)
            {
                throw new NegativeIdException();
            }
            GetCategoryDto dto = _mapper.Map<GetCategoryDto>(await _repo.GetbyId(id));
           
            return dto != null ?  dto : throw new CategoryNullException();
        }

        public async Task Delete(int id)
        {
            var category=await GetById(id);
            _repo.Delete(_mapper.Map<Category>(category));
            await _repo.SaveChangesAsync();
        }
        public async Task SoftDelete(int id)
        {
            var category = await GetById(id);
            _repo.SoftDelete(_mapper.Map<Category>(category));
            await _repo.SaveChangesAsync();
        }

        public async Task Update(UpdateCategoryDto dto)
        {
            var oldCategory= await GetById(dto.Id);
            if (await _repo.IsExsist(c => c.Name == dto.Name))
            {
                throw new CategoryNameExsistException();
            }
            oldCategory = _mapper.Map<GetCategoryDto>(dto);
            _repo.Update(_mapper.Map<Category>(oldCategory));
            await _repo.SaveChangesAsync();
        }

    
    }
}
