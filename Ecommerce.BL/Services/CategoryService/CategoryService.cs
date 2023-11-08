using AutoMapper;
using Ecommerce.BL.Dtos.ProductCategory;
using Ecommerce.BL.Dtos.ProductType;
using Ecommerce.DAL.Data.Models;
using Ecommerce.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BL.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper mapper;
        private readonly ICategoryReposiory categoryRepo;
        public CategoryService(IMapper _mapper,ICategoryReposiory _categoryRepo)
        {
            mapper= _mapper;
            categoryRepo= _categoryRepo;
        }

        public async Task<ReadCategoryDto> AddCategory(WriteCategoryDto writeCategoryDto)
        {
            var categoryToAdd = mapper.Map<Category>(writeCategoryDto);
            await categoryRepo.Add(categoryToAdd);
            categoryRepo.SaveChange();
            return new ReadCategoryDto { Id=categoryToAdd.Id,Name=categoryToAdd.Name };
        }

        public async Task<bool> DeleteCategory(int id)
        {
            var productFromDb=await categoryRepo.GetById(id);
            if(productFromDb == null) { return false; }
            categoryRepo.Delete(productFromDb);
            categoryRepo.SaveChange();
            return true;
        }

        public async Task<List<ReadCategoryDto>> GetAll()
        {
            var dataFromDb = await categoryRepo.GetAll();
            return mapper.Map<List<ReadCategoryDto>>(dataFromDb);
        }

        public async Task<ReadCategoryDto> GetById(int id)
        {
            var categoryFromDb = await categoryRepo.GetById(id);
            if(categoryFromDb == null) { return null; }
            return mapper.Map<ReadCategoryDto>(categoryFromDb);
        }

        public async Task<ReadCategoryDto> UpdateCategory(int id, UpdateCategoryDto updateCategoryDto)
        {
            var categoryFromDb = await categoryRepo.GetById(id);
            if(categoryFromDb == null) { return null; }
            categoryFromDb.Name=updateCategoryDto.Name;
            categoryRepo.SaveChange();
            return new ReadCategoryDto { Id = categoryFromDb.Id, Name = categoryFromDb.Name };
        }
    }
}
