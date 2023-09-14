using AutoMapper;
using Ecommerce.BL.Dtos.Product;
using Ecommerce.BL.Helpers;
using Ecommerce.DAL.Data.Models;
using Ecommerce.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
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

        public async Task<ReadProductDto?> GetById(int id)
        {
            var productFromDb = await productRepository.GetById(id);
            if(productFromDb == null) return null;
            return mapper.Map<ReadProductDto>(productFromDb);
        }

        public async Task<List<ReadProductDto>> GetProductsPaginated(int pageNumber, int pageSize)
        {
            var dataFromDb = await productRepository.GetProductPaginated(pageNumber, pageSize);
            return mapper.Map<List<ReadProductDto>>(dataFromDb);
        }
        public async Task<PagedCollectionResponse<ReadProductDto>> Get(ProductParams productParams)
        {
            IQueryable<Product> query = await productRepository.GetQuerableProducts();
            if(!string.IsNullOrEmpty(productParams.Sort))
            {
                switch(productParams.Sort)
                {
                    case "priceAsc":
                        query = query.OrderBy(p=>p.Price);
                        break;
                    case "priceDes":
                        query = query.OrderByDescending(p=>p.Price);
                        break;
                    default:
                        query = query.OrderBy(p => p.Name); 
                        break;
                }
            }
            if ((productParams.CategoryId != null) && (productParams.CategoryId != 0))
            {
                query= query.Where(p=>p.categoryId== productParams.CategoryId);
            }

            if (!string.IsNullOrEmpty(productParams.Search))
            {
                query = query.Where(p=>p.Name.Contains(productParams.Search));
            }
            var itemCount = query.Count();
            int skipedProducts = (productParams.PageNumber - 1) * productParams.PageSize;
            var data =await query.Skip(skipedProducts).Take(productParams.PageSize).ToListAsync();

            return new PagedCollectionResponse<ReadProductDto>
            {
                PageNumber = productParams.PageNumber,
                PageSize = productParams.PageSize,
                Count = itemCount,
                Data = mapper.Map<List<ReadProductDto>>(data)
            };
        }

        public async Task<List<ReadProductDto>> GetRelatedProducts(int categoryId, int productId, int productCount)
        {
            var productsFromDB = await productRepository.GetRelatedProducts(categoryId,productId, productCount);
            return  mapper.Map<List<ReadProductDto>>(productsFromDB);
        }
    }
}
