using AutoMapper;
using Ecommerce.BL.Dtos.Product;
using Ecommerce.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BL.Services.ProductService
{
    public class ProductService : IproductService
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;
        public ProductService(IProductRepository _productRepository,IMapper _mapper)
        {
            productRepository= _productRepository;
            mapper = _mapper;
        }
        public async Task<List<ReadProductDto>> GetAll()
        {
            var productFromDb = await productRepository.GetAll();
            return  mapper.Map<List<ReadProductDto>>(productFromDb);
        }
    }
}
