using AutoMapper;
using Ecommerce.BL.Dtos.ProductType;
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
        public async Task<List<ReadCategoryDto>> GetAll()
        {
            var dataFromDb = await categoryRepo.GetAll();
            return mapper.Map<List<ReadCategoryDto>>(dataFromDb);
        }
    }
}
