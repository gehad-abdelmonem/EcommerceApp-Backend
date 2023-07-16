using Ecommerce.BL.Dtos.Product;
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
    }
}
