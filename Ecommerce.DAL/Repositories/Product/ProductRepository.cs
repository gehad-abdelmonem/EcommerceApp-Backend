using Ecommerce.DAL.Data.Context;
using Ecommerce.DAL.Data.Models;
using Ecommerce.DAL.Repositories.Generic_Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DAL.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly StoreContext context;
        public ProductRepository(StoreContext _context) : base(_context)
        {
            context = _context;
        }

        public new async Task<List<Product>> GetAll()
        {
            return await context.Set<Product>()
                .Include(p=>p.category).ToListAsync();

        }

        public new async Task<Product?> GetById(int id)
        {
            return await context.Set<Product>()
                .Include(p => p.category).FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<List<Product>> GetRelatedProducts(int categoryId, int productId, int productCount)
        {
            return await context.Set<Product>().Where(p=>(p.categoryId==categoryId &&p.Id!=productId)).Take(productCount).ToListAsync();
        }

        public async Task<IQueryable<Product>> GetQuerableProducts()
        {
            IQueryable<Product> query =  context.Products.Include(p=>p.category);
            return  query;
        }
    }
}
