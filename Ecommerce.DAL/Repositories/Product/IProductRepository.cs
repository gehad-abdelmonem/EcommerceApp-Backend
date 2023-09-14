using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.DAL.Data.Models;
using Ecommerce.DAL.Repositories.Generic_Repository;

namespace Ecommerce.DAL.Repositories
{
    public interface IProductRepository: IGenerticRepository<Product>
    {
        Task<List<Product>> GetProductPaginated(int pageNumber, int pageSize);
        Task<IQueryable<Product>> GetQuerableProducts();
        Task<List<Product>> GetRelatedProducts(int categoryId, int productId,int productCount);
    }
}
