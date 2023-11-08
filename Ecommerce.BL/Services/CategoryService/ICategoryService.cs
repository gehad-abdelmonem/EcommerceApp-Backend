using Ecommerce.BL.Dtos.ProductCategory;
using Ecommerce.BL.Dtos.ProductType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BL.Services.CategoryService
{
    public interface ICategoryService
    {
        Task <List<ReadCategoryDto>> GetAll();
        Task<ReadCategoryDto> GetById(int id);
        Task<ReadCategoryDto> AddCategory(WriteCategoryDto writeCategoryDto);
        Task <bool> DeleteCategory(int id);
        Task<ReadCategoryDto> UpdateCategory(int id, UpdateCategoryDto updateCategoryDto);
    }
}
