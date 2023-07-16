using Ecommerce.DAL.Data.Context;
using Ecommerce.DAL.Data.Models;
using Ecommerce.DAL.Repositories.Generic_Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
            return await context.Set<Product>().Include(p=>p.ProductBrand)
                .Include(p=>p.ProductType).ToListAsync();

        }
    }
}
