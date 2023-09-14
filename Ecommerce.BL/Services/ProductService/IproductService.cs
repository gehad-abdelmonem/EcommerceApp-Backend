using Ecommerce.BL.Dtos.Product;
using Ecommerce.BL.Helpers;
using Ecommerce.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BL.Services.ProductService
{
    public interface IproductService
    {
        Task<List<ReadProductDto>> GetAll();
        Task<ReadProductDto?> GetById(int id);

        Task<List<ReadProductDto>> GetProductsPaginated(int pageNumber, int pageSize);
        Task<PagedCollectionResponse<ReadProductDto>> Get(ProductParams productParams);
        Task<List<ReadProductDto>> GetRelatedProducts(int categoryId,int productId,int productCount);
    }
}
